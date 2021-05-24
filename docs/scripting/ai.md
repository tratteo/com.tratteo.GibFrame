# GIbFrame.AI
This namespace provides some class that can help developing AI agents. 
- [Memory](#memory)
- [MemoryModule](#memorymodule)


## [Memory](https://github.com/tratteo/GibFrame/blob/main/Runtime/Scripts/AI/Memory.cs)
🟠 **Constructors**  
```c#
public Memory()
```
---
🟡 **Methods**  

---

```c#
public void Remember(params MemoryModule[] modules)
```
Remember  the memory modules  

---

```c#
public bool Knows(object obj)
```
↪ **Return**   
True if the memory knows the selected object

---

```c#
public List<MemoryModule> GetAllMemories()
```
↪ **Return**   
The list of all the memory modules

---

```c#
public T[] GetAllMemories<T>(Predicate<MemoryModule> predicate, Converter<MemoryModule, T> converter)
```
↪ **Return**   
An array of all the converted memory modules that matched the predicate

---

```c#
public MemoryModule Get(object obj)
```
↪ **Return**   
The memory module that represents the object

---

```c#
public bool Forget(object obj)
```
Try to forget the memory module that represents the object   
↪ **Return**    
True if the module was forgotten

---

```c#
public bool Forget(MemoryModule module)
```
Try to forget all the specified memory module   
↪ **Return**   
True if the module was forgotten

---

```c#
public int ForgetAll(Predicate<MemoryModule> predicate)
```
Try to forget all the memory modules that matches the predicates   
↪ **Return**   
The number of forgotten modules

---

```c#
public void Amnesia()
```
Forget all the memory modules

---

```c#
public bool IsValidMemory(MemoryModule module)
```
↪ **Return**   
True if the specified memory module corresponds to a valid object (not null)

---

## [MemoryModule](https://github.com/tratteo/GibFrame/blob/main/Runtime/Scripts/AI/MemoryModule.cs)
🟠 **Constructors**

---

```c#
public MemoryModule(object memory, float remembranceTime)
```

---

🟣 **Properties**

---

```c#
public float RemembranceTime { get; }
```
The current remembrance time of the module

---

```c#
public float InitialRemembranceTime { get; private set; }
```
The initial remembrance time of the module

---

```c#
public object Memory { get; private set; }
```
The object remembered   

---

🟡 **Methods**

---

```c#
public void Reset(float remembranceTime = -1)
```
Reset the remembrance time of the module to the specified remembrance time. If **-1** is passed, the remembrance time is set to the initial remembrance time

---

```c#
public void TimeStep(float step)
```
Decrease the remembrance time by **step** seconds
