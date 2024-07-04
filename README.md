# Tarject Dependency Injection Framework

## Table Of Contents
- [Introduction](#introduction)
- [Installation](#installation)
- [Context](#context)
- [Installer](#installer)
- [Binding](#binding)
- [Injecter](#injecter)
- [Factory](#factory)
- [Interfaces](#interfaces)
- [SignalBus](#signalbus)

## Introduction
Tarject is a framework developed for Unity Engine to prevent tight coupling between software modules.

## Installation
- In Unity, open Window/Package Manager
- Select the + button at the top left
- Select Add package from git URL...
- Paste in ```https://github.com/tariksavas/tarject.git```
- Click the Add button

## Context
The referenced `GameObjectInstallers` and `Container` are kept in Context, which is an abstract class. There are **3** different classes that inherit this class. Each context has a hierarchical parent context. If the relevant object cannot be found in the context during the `Resolve` process, it is searched in the parent context.
* **ProjectContext** = It is the `first` context to be executed in all Contexts. In the application, 1 ProjectContext can be defined. In Awake, `DontDestroyOnLoad` is called and `Instance` is kept statically. There is no parent context defined. It can be created in the scene by selecting `Tarject/ProjectContext` from the MenuItems.
* **SceneContext** = It is the `second` context to be executed in all Contexts. It carries the container of the scene in which it was created. As long as the scene runs, it runs. Parent context is defined as `ProjectContext`. It can be created in the scene by selecting `Tarject/SceneContext` from the MenuItems.
* **ProjectContext** = It is the `third` context to be executed in all Contexts. More than one GameObjectContext can be executed at the same time. Parent context is defined as `SceneContext`. It can be created in the scene by selecting `Tarject/GameObjectContext` from the MenuItems.

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
```
```csharp
public class FooInstaller : ObjectInstaller<FooInstaller>
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

## SignalBus
