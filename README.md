# Problem with tracing in .NET

This is an example showing that you will not get traces for an application unless they're all instrumented.

The frontend application is NOT instrumented, however, it's generating invisible, non-recorded/sampled, Activity objects. These are then propagated out to the backend which assumes that the current request has been traced, but discarded through head sampling.

If you remove the `.SetSampler<AlwaysOnSampler>()` line, you will not get spans. With that line, you'll get spans with a missing parent span/root span.

The Console output will also show that there is a parentId in the only spans that's emitted.