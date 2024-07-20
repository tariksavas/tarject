# Tarject Dependency Injection Framework

# Table Of Contents
* [Introduction](#introduction)
* [Installation](#installation)
* [How to Contribute](#how-to-contribute)
* [How to Use](#how-to-use)
    * [Context](#context)
    * [Installer](#installer)
    * [Binding](#binding)
    * [Binding Properties](#binding-properties)
    * [Injecter](#injecter)
    * [Factory](#factory)
    * [Interfaces](#interfaces)
    * [SignalBus](#signalbus)
    * [TestFramework](#testframework)

# Introduction
Tarject is a framework developed for Unity Engine to prevent tight coupling between software modules. It is a highly optimized and readable framework, using as little reflection as possible in Bind and Injection operations. 

# Installation
* In Unity, open Window/Package Manager
* Select the + button at the top left
* Select Add package from git URL...
* Paste in ```https://github.com/tariksavas/tarject.git```
* Click the Add button

# How to Contribute
I want the community to lead the growth of this project.
<br><br>If you want you can take part in this by:
* Create a pull request for upgrades or fixes
* Contact via email

**You can join [Discord](https://discord.gg/Sxsut2bxQb) for more**

# How to Use
After importing this Framework into your project, you can read this document to get information about how to use it and examine the `Samples` folder for sample uses.

## Context
The referenced `GameObjectInstallers` and `Container` are kept in Context, which is an abstract class. There are **3** different classes that inherit this class. Each context has a hierarchical parent context. If the relevant object cannot be found in the context during the `Resolve` process, it is searched in the parent context.
* **ProjectContext** = It is the `first` context to be executed in all Contexts. In the application, 1 ProjectContext can be defined. In Awake, `DontDestroyOnLoad` is called and `Instance` is kept statically. There is no parent context defined. It can be created in the scene by selecting `Tarject/ProjectContext` from the MenuItems.
* **SceneContext** = It is the `second` context to be executed in all Contexts. It carries the container of the scene in which it was created. As long as the scene runs, it runs. Parent context is defined as `ProjectContext`. It can be created in the scene by selecting `Tarject/SceneContext` from the MenuItems.
* **GameObjectContext** = It is the `third` context to be executed in all Contexts. More than one GameObjectContext can be executed at the same time. Parent context is defined as `SceneContext`. It can be created in the scene by selecting `Tarject/GameObjectContext` from the MenuItems.

## Installer
There are two types of installers: `GameObjectInstaller` and `ObjectInstaller`. These installers have an abstract `Install` method where bind operations are called. The container in the context in which the installs are called is also sent as a parameter to this method.
* **GameObjectInstaller** = The installers in the scene must be derived from this class and referenced in any context in the scene.
```csharp
public class AppInstaller : GameObjectInstaller
{
    public override void Install(DIContainer container)
    {
       container.Bind<Foo>();

        FooInstaller.CreateAndInstall(container);
    }
}
```
```csharp
internal class TarjectDemoSceneInstaller : GameObjectInstaller
{
    public override void Install(DIContainer container)
    {
        container.Bind<Foo>();

        FooInstaller.CreateAndInstall(container);
    }
}
```
* **ObjectInstaller** = Installers that we do not want to be present in the scene and that we call from another `GameObjectInstaller` must be derived from this class. The relevant installer is created by calling the `CreateAndInstall` method from GameObjectInstaller. The relevant container is also sent as a parameter.
```csharp
public class AppInstaller : GameObjectInstaller
{
    public override void Install(DIContainer container)
    {
        FooInstaller.CreateAndInstall(container);
    }
}

public class FooInstaller : ObjectInstaller<FooInstaller>
{
    public override void Install(DIContainer container)
    {
        container.Bind<Foo>().WithId("foo1");
        container.Bind<FooController>();
    }
}
```
```csharp
public class AppInstaller : GameObjectInstaller
{
    public override void Install(DIContainer container)
    {
        ObjectInstaller.CreateAndInstall<FooInstaller>(container);
    }
}

public class FooInstaller : ObjectInstaller
{
    public override void Install(DIContainer container)
    {
        container.Bind<Foo>().WithId("foo1");
        container.Bind<FooController>();
    }
}
```

## Binding
The bind method is called to bind objects to a container. As long as the container in which the object is bound is alive, objects are also run in that container. There are **4** different bind methods.
* **Bind** = It is called to bind a class that does not have an object.
```csharp
container.Bind<Foo>();
```
* **BindFromInstance** = It is called to bind a class that has an object. The object must be given as a reference when calling the relevant method.
```csharp
container.BindFromInstance<Foo>(object);
```
* **BindFromHierarchy** = It is called when a class that has an object in the scene. The object is searched in the scene where the container is located.
```csharp
container.BindFromHierarchy<Foo>();
```
* **BindFactory** = It is called to bind factory classes. Whichever container the factory is bound to, the dependencies of the objects produced from that factory are also searched in that container.
```csharp
container.BindFactory<GameObjectFactory>();
```

## Binding Properties
It includes methods of binding objects.
* **ToInterface** = It ensures that the binded object is stored in interface type. In this way, the implementation can be abstracted and dependency on the injected classes is minimized. Whichever implementation of the interface is bound, that implementation is injected.
```csharp
public class AppInstaller : GameObjectInstaller
{
    public override void Install(DIContainer container)
    {
        container.Bind<StaticConfigurationService>().ToInterface<IConfigurationService>();
    }
}
public class Foo : MonoBehaviour
{
    [Inject]
    private readonly IConfigurationService _configurationService; //StaticConfigurationService object Injected
}
```
* **WithId** = It is used to specify a binded object according to its id. In this way, more than one object from the same class can be binded with different ids. While injecting, the object is resolved according to the specified id.
```csharp
public class AppInstaller : GameObjectInstaller
{
    public override void Install(DIContainer container)
    {
        container.Bind<InventoryData>().WithId("inventory1");
        container.Bind<InventoryData>().WithId("inventory2");
    }
}
public class FooMono : MonoBehaviour
{
    [Inject("inventory1")]
    private readonly InventoryData _inventoryDataFirst;
    [Inject("inventory2")]
    private readonly InventoryData _inventoryDataSecond;
}
public class Foo
{
    private readonly InventoryData _inventoryDataFirst;
    private readonly InventoryData _inventoryDataSecond;

    public Foo([Inject("inventory1")] InventoryData inventoryDataFirst, [Inject("inventory2")] InventoryData inventoryDataSecond)
    {
        _inventoryDataFirst = inventoryDataFirst;
        _inventoryDataSecond = inventoryDataSecond;
    }
}
```
* **Lazy** = Objects are created from lazy binded classes only when needed. If the class is not Lazy Bind, an object from that class is created in the relevant Context's Awake, but if Lazy Bind is made, the object is created only when there is a place to be injected.
```csharp
public class AppInstaller : GameObjectInstaller
{
    public override void Install(DIContainer container)
    {
        container.Bind<InventoryData>().Lazy();
    }
}
public class FooMono : MonoBehaviour
{
    [Inject]
    private readonly InventoryData _inventoryData; //InventoryData is created and injected when FooMono is instantiated
}
```

## Injecter
Inject is the process of getting the binded objects from the container. There are various ways to assign dependencies of an object. The dependencies of objects derived from MonoBehaviour are given in the `Definitions`, the dependencies of objects that do not derive from MonoBehaviour are given in the `Constructor`. 
<br><br>In order to assign injections to these objects, the Inject attribute must first be used. It is not necessary to use it in the constructor, it just increases the injection priority.
<br><br>**InjectAttribute** = `Inject` attribute can be applied to `Field`, `Property`, `Method`, `Constructor` and `Parameter`. This attribute also keeps the `id` received while binding and ensures that it is injected according to the relevant id.
```csharp
public class SampleClass : MonoInjecter
{
    [Inject]
    private readonly SignalController _signalController;

    [Inject("foo1")]
    private readonly Foo _foo;
}
```
```csharp
public class SampleClass
{
    private readonly Foo _foo;

    public SampleClass([Inject("foo1")] Foo foo)
    {
        _foo = foo;
    }
}
```

If a class has more than one constructor, whichever constructor has the inject attribute is called. 
```csharp
public class SampleClass
{
    private readonly Foo _foo;

    public SampleClass(Foo foo) //Not called
    {
        _foo = foo;
    }

    [Inject]
    public SampleClass() //Called
    {
    }
}
```

If the inject attribute is not used at all, the one with the largest number of parameters is called.
```csharp
public class SampleClass
{
    private readonly Foo _foo;

    public SampleClass(Foo foo) //Called
    {
        _foo = foo;
    }

    public SampleClass() //Not called
    {
    }
}
```

There are **3** different injection methods
* **MonoInjecter** = If there is a `MonoBehaviour` object that is not created with Factory, the fastest way to give dependencies is to derive this class from `MonoInjecter`. With this class, dependencies are injected from the `SceneContext` in `Awake` method.
* **SceneInjecter** = If there is a `MonoBehaviour` object that is not created with Factory and does not derive from MonoInjecter, another way to give dependencies is to have a `SceneInjecter` in the scene. This class finds all MonoBehaviors in the entire scene in `Awake` and injects their dependencies one by one from the relevant `SceneContext`. It can be created in the scene by selecting `Tarject/SceneInjecter` from the MenuItems. It is recommended to inherit each scene object to be injected from MonoInjecter for faster injecting.
* **Factory** = Another way to give the dependencies of objects is to create the relevant object with Factory. During creation, dependencies are injected from the container of the context to which the Factory is binded. This method can be used for all objects.

## Factory
Objects can be created with Factory to assign dependencies and initialize them with parameters. Whichever container the Factory is binded, the dependencies of the created objects are injected from that container. There are **2** different Factory classes that inherit from the abstract Factory class.
* **GameObjectFactory** = It is used to instantiate objects derived from MonoBehaviour.
```csharp
public class Installer : GameObjectInstaller
{
    public override void Install(DIContainer container)
    {
        container.BindFactory<GameObjectFactory>();
    }
}

public class SampleClass : MonoInjecter
{
    [Inject]
    private readonly GameObjectFactory _gameObjectFactory;

    [SerializeField]
    private FooItem _fooItemPrefab;

    protected override void Awake()
    {
       base.Awake();

        _gameObjectFactory.Create(_fooItemPrefab, "Sample string");
    }
}

public class FooItem : MonoBehaviour,  IFactorable<string>
{
    [Inject]
    private readonly Foo _foo;

    public void InitializeFactory(string variable)
    {
        Debug.Log($"{_foo.index}: String variable is: {variable}");
    }
}
```
* **ObjectFactory** = It is used to create objects that do not derive from MonoBehaviour.
```csharp
public class Installer : GameObjectInstaller
{
    public override void Install(DIContainer container)
    {
        container.BindFactory<ObjectFactory>();
    }
}

public class SampleClass : MonoInjecter
{
    [Inject]
    private readonly ObjectFactory _objectFactory;

    protected override void Awake()
    {
        base.Awake();

        _objectFactory.Create<FooItem, string>("Sample string");
    }
}

public class FooItem : IFactorable<string>
{
    private readonly Foo _foo;

    public FooItem(Foo foo)
    {
        _foo = foo;
    }

    public void InitializeFactory(string variable)
    {
        Debug.Log($"{_foo.index}: String variable is: {variable}");
    }
}
```

## Interfaces
These interfaces must be implemented to use Unity frame actions on binded objects that do not derive from MonoBehaviour. The methods of the relevant object are triggered by the Unity frame actions of the context in which it is binded. There are **5** different interfaces:
* **IInitializable** = In the relevant context, there is the `Initialize` method called in `Awake`
* **IFixedUpdatable** = In the relevant context, there is the `FixedUpdate` method called in `FixedUpdate`
* **IUpdatable** = In the relevant context, there is the `Update` method called in `Update`
* **ILateUpdatable** = In the relevant context, there is the `LateUpdate` method called in `LateUpdate`
* **ILateDisposable** = In the relevant context, there is the `LateDispose` method called in `OnDestroy`

## SignalBus
Actions that listen for signals are kept in SignalBus. When the relevant signal is fired, listening actions are triggered. In this way, there is no dependency between the place that fires the signal and the place that listens.
```csharp
public class Installer : GameObjectInstaller
{
    public override void Install(DIContainer container)
    {
        container.Bind<SignalController>();
    }
}

public readonly struct FooSignal
{
    public readonly string Data;

    public FooSignal(data)
    {
        Data = data;
    }
}

public class SampleClass : MonoInjecter
{
    [Inject]
    private readonly SignalController _signalController;

    protected override void Awake()
    {
        base.Awake();

        SubscribeEvents();
    }

    private void SubscribeEvents()
    {
        _signalController.Subscribe<FooSignal>(OnFoo);
    }

    private void OnFoo(string signal)
    {
        Debug.Log($"Signal Received - string: {signal.Data}");
    }

    private void UnsubscribeEvents()
    {
        _signalController.Unsubscribe<UserDataReceivedSignal>(OnUserDataReceived);
    }

    private void OnDestroy()
    {
        UnsubscribeEvents();
    }
}

public class FooItem : MonoInjecter
{
    [Inject]
    private readonly SignalController _signalController;

    protected override void Awake()
    {
        base.Awake();

        _signalController.Fire(new FooSignal("Sample string from {transform.name]"));
    }
}
```

## TestFramework
For now there is only `UnitTest` support. There is an abstract `TarjectUnitTestFixture` class that creates a temporary `Container` to run UnitTests.
```csharp
public class SignalControllerTest : TarjectUnitTestFixture
{
    protected override void Setup()
    {
        Container.Bind<SignalController>();
    }

    [Test]
    public void Subscribe()
    {
        SignalController signalController = Container.Resolve<SignalController>();
        signalController.Subscribe<TestSignal>(Action);

        void Action(TestSignal _) { }

        Assert.IsTrue(signalController.Exists<TestSignal>(Action));
    }

    [Test]
    public void Unsubscribe()
    {
        SignalController signalController = Container.Resolve<SignalController>();
        signalController.Subscribe<TestSignal>(Action);
        signalController.Unsubscribe<TestSignal>(Action);

        void Action(TestSignal _) { }

        Assert.IsFalse(signalController.Exists<TestSignal>(Action));
    }
                    
    private readonly struct TestSignal
    {
    }
}
```
