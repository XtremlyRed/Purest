# Purest 

### 1 MVVM

```csharp
// View Model
public class TinyViewModel : BindableBase
{
    public string Name
    {
        get => GetValue<string>();
        set => SetValue(value);
    }

    int age;
    public int Age
    {
        get => age;
        set => SetValue(ref age,value);
    }

    // command
    public ICommand ClickCommand => RelayCommand.Bind(() => 
    {
        MessageBox.Show("ok");
    });
}
```

### 2 Folder

```csharp
public string GetDesktopFolder()
{
    return Folder.Desktop;
}

public string CombinePath(string path1,string path2)
{
    //automatically create a folder when converting to a string
    return Folder.Desktop.Combine(path1, path2);
}
```

### 3 EventManager

EventManager  IEventManager

```csharp
EventManager eventManager = new EventManager();

var @event = eventManager.GetEvent<int>();

event.Subscribe(i=>Console.WriteLine(i));

event.Publish(100);

```

### 4 Extensions  

#### 4.1 EnumerableExtensions

```csharp
var enumerableCollection = Enumerable.Range(0, 1000).Select(i => new
{
        Target = $"{i}",
        Count = i
});

enumerableCollection.ForEach(item =>
{
        // do something
});

enumerableCollection.ForEach((item,index) =>
{
        // do something
});

if (enumerableCollection.IsNullOrEmpty())
{
        // do something
}
```

#### 4.2 MathExtensions

```csharp
int a = 100;
int b = a.FromRange(0, 50);
//b=50

var a1 = 100;
bool result = a1.InRange(200, 1000);
//result=false
```


#### 4.3 More ...

，，，，
