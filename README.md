# Nancy.Boostrapper.Experiments
Testing the behaviour of various Nancy bootstrappers

## Why?

I had some issues with Nancy bootstrappers, the `Registrations` class and how various DI containers conusme these registrations.

In this repository I'm comparing the available bootstrappers to see how the operate in different circumstances.

In my opinion the `Registrations` class should help unify the basic container API so that publishers of libraries extending Nancy
can be sure that the behaviour will be the same regardless of the bootstrapper chosen by the consumer.

## The tests

1. [`Register<T>(Lifetime.PerRequest)`, where `T` has dependency registered inside bootstrapper](https://github.com/tpluscode/Nancy.Boostrapper.Experiments/blob/master/Nancy.Bootstrapper.TestSubjects/Test1.cs)
2. [Mutiple calls to `Register<T>(Lifetime.Singleton)` - injected as `IEnumerable<T>`](https://github.com/tpluscode/Nancy.Boostrapper.Experiments/blob/master/Nancy.Bootstrapper.TestSubjects/Test2.cs)
3. [`RegisterAll<T>(Lifetime.Singleton)` - injected as `IEnumerable<T>`](https://github.com/tpluscode/Nancy.Boostrapper.Experiments/blob/master/Nancy.Bootstrapper.TestSubjects/Test3.cs)
4. [Mutiple calls to `Register<T>(Lifetime.PerRequest)` - injected as `IEnumerable<T>`](https://github.com/tpluscode/Nancy.Boostrapper.Experiments/blob/master/Nancy.Bootstrapper.TestSubjects/Test4.cs)
5. [`RegisterAll<T>(Lifetime.PerRequest)` - injected as `IEnumerable<T>`](https://github.com/tpluscode/Nancy.Boostrapper.Experiments/blob/master/Nancy.Bootstrapper.TestSubjects/Test5.cs)

### Test Results

| Test ------------------>                 | 1  | 2             | 3             | 4             | 5             |
| ---------------------------------------- |----|---------------|---------------|---------------|---------------| 
| TinyIoC                                  |:+1:|:+1:           |:+1:           |:+1:           |:x:<sup>1</sup>|
| TinyIoC (no auto reg)                    |:+1:|:x:<sup>2</sup>|:+1:           |:x:<sup>2</sup>|:+1:           |
| [Autofac][Autofac]                       |:+1:|:+1:           |:+1:           |:+1:           |:+1:           |
| [DryIoc][DryIoc]                         |:+1:|:+1:           |:+1:           |:+1:           |:+1:           |
| [Grace][Grace]<sup>1</sup>               |:x: |:x:            |:x:            |:x:            |:x:            |
| [LightInject][LightInject]<sup>1,2</sup> |:+1:|:x:<sup>3</sup>|:+1:           |:x:<sup>3</sup>|:+1:           |
| [MEF][MEF]<sup>1</sup>                   |:x: |:x:            |:x:            |:x:            |:x:            |
| [MEF2][MEF2]                             |:+1:|:+1:           |:x:<sup>1</sup>|:+1:           |:x:<sup>1</sup>|
| [Ninject][Ninject]                       |:+1:|:+1:           |:+1:           |:+1:           |:+1:           |
| [StructureMap][StructureMap]             |:+1:|:+1:           |:+1:           |:+1:           |:+1:           |
| [Unity][Unity]<sup>1</sup>               |:+1:|:x:<sup>2</sup>|:+1:           |:x:<sup>2</sup>|:+1:           |
| [Windsor][Windsor]<sup>1</sup>           |:+1:|:+1:           |:+1:           |:+1:           |:+1:           |

### Test notes

### TinyIoC

**<sup>1</sup>** - When autoregistration is enabled, PerRequest components are resolved twice. I guess they are registered in both scopes. See issue [NancyFx/Nancy#2384](https://github.com/NancyFx/Nancy/issues/2384)

**<sup>2</sup>** - TinyIoC resolves collections only if registered with `RegisterAll`/`RegisterMultiple`

### Grace

**<sup>1</sup>** - Grace package has an outdated Nancy dependency and doesn't work with latest version.

### MEF

**<sup>1</sup>** - MEF package has an outdated Nancy dependency and doesn't work with latest version.

### MEF2

**<sup>1</sup>** - this one is weird - `RegisterAll<T>()` has no effect with MEF2

### Windsor

**<sup>1</sup>** - Windsor doesn't create a child container but uses a per-request scope. This is a problem for tests and transient registration was used instead

### LightInject 

**<sup>1</sup>** - LightInject doesn't create a child container. Instead `PerScopeLifetime` must be used. 

**<sup>2</sup>** - LightInject requires .NET 4.5.1

**<sup>3</sup>** - LightInject registers only one instance of a component when `Register<>()` is called multiple times

### Unity

**<sup>1</sup>** - Unity bootstrapper has a dependency on Unity >= 2.1.505 and works fine with version 3.5, but breaks with 4.0.

**<sup>2</sup>** - Unity registers only one instance of a component when `Register<>()` is called multiple times

[Autofac]: https://github.com/NancyFx/Nancy.Bootstrappers.Autofac
[DryIoc]: https://github.com/lcssk8board/Nancy.Bootstrappers.DryIoc
[Grace]: https://github.com/ipjohnson/Nancy.Bootstrappers.Grace
[MEF]: https://github.com/wasabii/Nancy.Bootstrappers.Mef
[MEF2]: https://github.com/AaronShiels/Nancy.Bootstrappers.Mef2
[Ninject]: https://github.com/NancyFx/Nancy.Bootstrappers.Ninject
[StructureMap]: https://github.com/NancyFx/Nancy.Bootstrappers.StructureMap
[Unity]: https://github.com/NancyFx/Nancy.Bootstrappers.Unity
[Windsor]: https://github.com/NancyFx/Nancy.Bootstrappers.Windsor
[LightInject]: http://seesharper.github.io/LightInject/#nancy
