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
    - Lowest-level constructs of multi-threading
    - Complicated process to return a value from a separate thread
    - to get value from another thread:
        - use a shared field to store the value from worker thread
        - use join to wait for the thread
        - access the value of shared field from main thread

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

Tasks:
    - Higher-level abstractions of thread
    - Capable of returning values
    - Can be chained
    - May use a thread pool
    - Very handy for I/O bound operations
    - CPU Bound operations:
        - Uses resources of a local machine
    - I/O Bound operations:
        - Out-of-process calls(call to db, api, webServer ..etc)
        - Operations can take an indeterminate amount of time becaus..
        - Release local resources while waiting for response
        - For these operations, Tasks can use TaskCompletionSource

    - Continuation:
        - Asynchronous task that is invoked by another task called a..
    - Task Chaining:
        - Pass data from the antecedent to the continuation task
        - Use exception passing from antecedent to continuation
        - Control how the continuation is invoked
        - Able to cancel continuation
        - Invoke multiple continuation from same antecedent
        - Invoke continuation based on completion of antecedents
```
---- 

Produced by [yaml2md](https://www.google.com) and [pandoc](pandoc.org)
