```yaml
Context Switching:
    thread scheduler :
        - CLR assigns local memory stack for each thread
        - static variables are shared between threads
    Timeslicing in single processor:
        - rapidly switch execution between each of the active threads
        - tens of milliseconds in windows
    preempted thread:
        - thread that has the execution interrupted, usually by time..
        - thread has no control over when and where it is preempted
Threads:
    - Run in parallel within a single process
    - Share memory(Heap) with other threads running in the same appl..

Processes:
    - Are fully isolated from each other

Thread Pool:
    - Every thread has overhead in time and memory
    - Thread pools reduce the performance penalty by sharing and rec..
    - Thread pools only create background threads
    - Limits the no of threads that can run simultaneously
    - When limit is reached, all jobs from a queue and begin only wh..
    - Thread.CurrentThread.IsThreadPoolThread property - determines ..
    - Ways to enter a Thread Pool:
        - TPL
        - Asynchronous delegate
        - Background worker
        - Call ThreadPool.QueueUserWorkItem

Background Thread:
    - Identical to foreground threads, except the managed execution ..
    - If the main thread dies, background threads will terminate abr..
```
---- 

Produced by [yaml2md](https://www.google.com) and [pandoc](pandoc.org)
