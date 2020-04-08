# API Helper


## How to use?

- Install form nuget package via visual studio or form nuget website directlly.
- after installing in your project use this code in your program.cs or any file that used as initializer for your project type.

```C# COde
ApiHelperConfig.InitializeClient();
```

- To use api actions there is a class called ```DataProcessor``` that contains methods for (GET,POST,PUT,DELETE) actions.


- #### Example
  here i try to read data form an api , to do this i will use this code.
> NOTE: when you call any one of this methods you have to do this inside of an aysnc method.


```C# Code
var result = await DataProcessor.Get<[YourDataModelType]>("your get end point url");
```



> NOTE: This ```Get``` method will return an IEnumerable of type you spcified.