# Proposed order to see and understand the steps/topics

1. 04-continuation-example
    - how a simple continuation builds up and what is the execution/output order
2. 05-cancellation-with-exception-example
    - cancellation handled with exceptions and try-catch
3. 06-cancellation-demo-with-continuation
    - cancellation handled with continuation
4. 07-lock
    - simple lock problem and solution
5. 02-rss-reader-v1
    - complex exercise where RSS data is read in parallel, executed in parallel and opened randomly one. this process can be cancelled. if not cancelled, then continuation is used.
6. 02-rss-reader-v2
    - complex exercise where RSS data is read in parallel, executed in parallel and opened randomly one. this process can be cancelled. cancellation can be handled separately for each Task as well as the successful runs with continuation.