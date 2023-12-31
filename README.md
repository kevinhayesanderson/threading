```yaml
Context Switching:
    thread scheduler:
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
          - Operations can take an indeterminate amount of time beca..
          - Release local resources while waiting for response
          - For these operations, Tasks can use TaskCompletionSource

    - Continuation:
          - Asynchronous task that is invoked by another task called..
    - Task Chaining:
          - Pass data from the antecedent to the continuation task
          - Use exception passing from antecedent to continuation
          - Control how the continuation is invoked
          - Able to cancel continuation
          - Invoke multiple continuation from same antecedent
          - Invoke continuation based on completion of antecedents

Synchronization:
    - Act of coordinating actions of multiple threads or tasks runni..
    - Necessary when running multiple threads to get predictable out..
    - Methods to Synchronization:
          - Blocking Methods:
                - Sleep
                - Join
                - Task.Wait
          - Locks:
                - Limit the no of threads
                - Exclusive locks:
                      - Allow only one thread to access a certain se..
                      - Alternative is to use Monitor.Enter/Monitor...
                      - Two kinds:
                            - Lock
                            - Mutex
                - Nonexclusive Locks:
                      - Allow multiple threads to access a resource
                      - They are:
                            - Semaphore
                            - SemaphoreSlim
                            - Reader/writer
          - Signals:
                - Allow threads to pause until they receive a signal..
                - They are:
                      - Event wait handles and Monitor's Wait/Pulse ..
                      - CountdownEvent and Barrier classes
          - Nonblocking constructs:
                - Protect access to a common field
                - They are:
                      - Thread.MemoryBarrier
                      - Thread.VolatileRead
                      - Thread.VolatileWrite
                      - volatile keyword
                      - Interlocked class
    - Blocking:
          - Blocked threads do not consume CPU
          - Blocked threads do consume memory
    - Spinning:
          - Consumes CPU for as long as the thread is blocked
          - while(x < limit)//uses CPU as long as the conditions is ..

Useful Links:
    - https://www.albahari.com/

Thread Safety:
    - Code is thread safe if shared data structures are modified to ..
      do not have unintended interactions
    - .Net Framework static methods are thread safe
    - Not all developer created static methods are thread safe
    - When creating static methods,it is a best practice to make the..

Thread Affinity:
    - Thread that instantiates an object is the only thread that is ..
    - Pros:
        - Don't need a lock to access a UI object in WPF
        - Able to access all objects within a thread without a lock,
          since no other thread can access them
    - Cons:
        - Cannot call members on a thread that is thread safe from a..
        - Requires request to be marshaled to the thread-safe thread..

Signaling:
    - Synchronize shared resources among threads
    - Is used to notify another thread that it can not access a reso..
      that was being used by the current thread
    - Three EventWaitHandle calls for signaling:
      - AutoResetEvent:
        - used when a thread needs exclusive access to resource
        - only one thread can access a resource at a time
        - automatically closes
        - A thread waits for a signal by calling WaitOne
        - Calling Set signals release of a waiting thread
        - If multiple threads call WaitOne, a queue is formed
        - If Set is called when no thread is waiting, the handle sta..
        - Calling Set only releases one thread at a time, regardless..
        - Can be created with an initial state of "signaled" by pass..
      - ManualResetEvent:
        -
      - CountdownEvent:

Task Parallel Library (TPL):
    - Simplifies process of adding parallelism and concurrency to ap..
    - Value is ability to scale degree of concurrency dynamically
    - Handles partitioning of work
    - Schedules threads on ThreadPool
    - Allows for task cancellation
    - Handles state management
    - Not all code is suitable for parallelization
    - Threading of any type has an associated overhead
    - In some cases, multi-threading may be slower than sequential c..
    - Set of public types and APIs found in :
        - System.Threading
        - System.Threading.Tasks

PLINQ:
    - Automates parallelization
    - Is declarative, not imperative
    - Operators that can prevent a query from being parallelized:
        - Take
        - Select
        - SelectMany
        - Skip
        - TakeWhile
        - SkipWhile
        - ElementAt
    - Parallelized queries are not always faster than regular queries
    - Anomalies:
        - Join
        - GroupBy
        - GroupJoin
        - Distinct
        - Union
        - Intersect
        - Except
    - Parallel queries can sometimes be executed sequentially
    - Force parallelism by calling the following after AsParallel():
        - .withExecutionMode(ParallelExecution.ForceParallelism)
    - Merge Options in PLINQ:
        - NotBuffered
        - AutoBuffered
        - FullyBuffered

Task-Based Asynchronous Pattern (TAP):
        - Returns Task or Task<TResult>
        - Uses Async suffix
        - Overloaded to accept cancellation token or IProgress<T>
        - Returns quickly to the caller
        - Frees up the thread if I/O bound
```
---- 

Produced by [yaml2md](https://www.google.com) and [pandoc](pandoc.org)
