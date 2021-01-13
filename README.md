# Purpose

This application is related to issue [Elasticsearch operations produce span retrieve error in distributed transactions #1094](https://github.com/elastic/apm-agent-dotnet/issues/1094#issuecomment-757613543) from elastic
/
apm-agent-dotnet repository.


## Infrastructure

Create the Docker network first.

```bash
docker network create itfnetwork
```
Then launch the infrastructure (Elk stack)

```bash
cd .\infrastructure\ 
docker-compose up -d
```

## Usage
Launch the app in debug using Docker-Compose (from Visual Studio).
Starting the app will launch a Background service reproducing the errors.

## Errors
The log produces the following.
```
warn: Microsoft.AspNetCore.HttpsPolicy.HttpsRedirectionMiddleware[3]
      Failed to determine the https port for redirect.
Microsoft.AspNetCore.HttpsPolicy.HttpsRedirectionMiddleware: Warning: Failed to determine the https port for redirect.
Loaded '/usr/share/dotnet/shared/Microsoft.AspNetCore.App/5.0.1/Microsoft.AspNetCore.WebUtilities.dll'. Skipped loading symbols. Module is optimized and the debugger option 'Just My Code' is enabled.
Loaded '/usr/share/dotnet/shared/Microsoft.NETCore.App/5.0.1/System.Security.Principal.dll'. Skipped loading symbols. Module is optimized and the debugger option 'Just My Code' is enabled.
Loaded '/usr/share/dotnet/shared/Microsoft.NETCore.App/5.0.1/System.Net.WebSockets.dll'. Skipped loading symbols. Module is optimized and the debugger option 'Just My Code' is enabled.
info: APMSpanErrorRepro.TestGarbageService[0]
      TestGarbageService is starting
APMSpanErrorRepro.TestGarbageService: Information: TestGarbageService is starting
Elastic.Apm: Information: {RequestPipelineDiagnosticsListener} Received an CallElasticsearch.Start event from elasticsearch
info: Elastic.Apm[0]
      {RequestPipelineDiagnosticsListener} Received an CallElasticsearch.Start event from elasticsearch
info: Elastic.Apm[0]
      {HttpConnectionDiagnosticsListener} Received an SendAndReceiveHeaders.Start event from elasticsearch
Elastic.Apm: Information: {HttpConnectionDiagnosticsListener} Received an SendAndReceiveHeaders.Start event from elasticsearch
Loaded '/usr/share/dotnet/shared/Microsoft.NETCore.App/5.0.1/System.Reflection.Metadata.dll'. Skipped loading symbols. Module is optimized and the debugger option 'Just My Code' is enabled.
Loaded '/usr/share/dotnet/shared/Microsoft.NETCore.App/5.0.1/System.Collections.Immutable.dll'. Skipped loading symbols. Module is optimized and the debugger option 'Just My Code' is enabled.
Loaded '/usr/share/dotnet/shared/Microsoft.NETCore.App/5.0.1/System.IO.MemoryMappedFiles.dll'. Skipped loading symbols. Module is optimized and the debugger option 'Just My Code' is enabled.
Elastic.Apm: Error: {HttpConnectionDiagnosticsListener} Failed to find current span in ConcurrentDictionary 00-8b5c2b0556c0964892e20625f30dc54f-74d4e8a1fbc8ab42-01
fail: Elastic.Apm[0]
      {HttpConnectionDiagnosticsListener} Failed to find current span in ConcurrentDictionary 00-8b5c2b0556c0964892e20625f30dc54f-74d4e8a1fbc8ab42-01
info: Elastic.Apm[0]
      {HttpConnectionDiagnosticsListener} Received an ReceiveBody.Start event from elasticsearch
Elastic.Apm: Information: {HttpConnectionDiagnosticsListener} Received an ReceiveBody.Start event from elasticsearch
Elastic.Apm: Information: {SerializerDiagnosticsListener} Received an Deserialize.Start event from elasticsearch
info: Elastic.Apm[0]
      {SerializerDiagnosticsListener} Received an Deserialize.Start event from elasticsearch
Loaded '/usr/share/dotnet/shared/Microsoft.NETCore.App/5.0.1/System.Reflection.Emit.dll'. Skipped loading symbols. Module is optimized and the debugger option 'Just My Code' is enabled.
Loaded 'Elasticsearch.Net.DynamicCompositeResolver'. 
fail: Elastic.Apm[0]
      {SerializerDiagnosticsListener} Failed to find current span in ConcurrentDictionary 00-8b5c2b0556c0964892e20625f30dc54f-874cea13ebe5e243-01
Elastic.Apm: Error: {SerializerDiagnosticsListener} Failed to find current span in ConcurrentDictionary 00-8b5c2b0556c0964892e20625f30dc54f-874cea13ebe5e243-01
fail: Elastic.Apm[0]
      {HttpConnectionDiagnosticsListener} Failed to find current span in ConcurrentDictionary 00-8b5c2b0556c0964892e20625f30dc54f-74d4e8a1fbc8ab42-01
Elastic.Apm: Error: {HttpConnectionDiagnosticsListener} Failed to find current span in ConcurrentDictionary 00-8b5c2b0556c0964892e20625f30dc54f-74d4e8a1fbc8ab42-01
fail: Elastic.Apm[0]
      {RequestPipelineDiagnosticsListener} Failed to find current span in ConcurrentDictionary 00-8b5c2b0556c0964892e20625f30dc54f-2db699c61329204d-01
Elastic.Apm: Error: {RequestPipelineDiagnosticsListener} Failed to find current span in ConcurrentDictionary 00-8b5c2b0556c0964892e20625f30dc54f-2db699c61329204d-01
info: Elastic.Apm[0]
      {RequestPipelineDiagnosticsListener} Received an CallElasticsearch.Start event from elasticsearch
Elastic.Apm: Information: {RequestPipelineDiagnosticsListener} Received an CallElasticsearch.Start event from elasticsearch
Loaded '/usr/share/dotnet/shared/Microsoft.NETCore.App/5.0.1/System.IO.Compression.dll'. Skipped loading symbols. Module is optimized and the debugger option 'Just My Code' is enabled.
Elastic.Apm: Information: {SerializerDiagnosticsListener} Received an Serialize.Start event from elasticsearch
info: Elastic.Apm[0]
      {SerializerDiagnosticsListener} Received an Serialize.Start event from elasticsearch
fail: Elastic.Apm[0]
      {SerializerDiagnosticsListener} Failed to find current span in ConcurrentDictionary 00-8b5c2b0556c0964892e20625f30dc54f-37f41deb5a297940-01
Elastic.Apm: Error: {SerializerDiagnosticsListener} Failed to find current span in ConcurrentDictionary 00-8b5c2b0556c0964892e20625f30dc54f-37f41deb5a297940-01
info: Elastic.Apm[0]
      {HttpConnectionDiagnosticsListener} Received an SendAndReceiveHeaders.Start event from elasticsearch
Elastic.Apm: Information: {HttpConnectionDiagnosticsListener} Received an SendAndReceiveHeaders.Start event from elasticsearch
Elastic.Apm: Error: {HttpConnectionDiagnosticsListener} Failed to find current span in ConcurrentDictionary 00-8b5c2b0556c0964892e20625f30dc54f-37f41deb5a297940-01
fail: Elastic.Apm[0]
      {HttpConnectionDiagnosticsListener} Failed to find current span in ConcurrentDictionary 00-8b5c2b0556c0964892e20625f30dc54f-37f41deb5a297940-01
info: Elastic.Apm[0]
      {HttpConnectionDiagnosticsListener} Received an ReceiveBody.Start event from elasticsearch
Elastic.Apm: Information: {HttpConnectionDiagnosticsListener} Received an ReceiveBody.Start event from elasticsearch
info: Elastic.Apm[0]
      {SerializerDiagnosticsListener} Received an Deserialize.Start event from elasticsearch
Elastic.Apm: Information: {SerializerDiagnosticsListener} Received an Deserialize.Start event from elasticsearch
fail: Elastic.Apm[0]
      {SerializerDiagnosticsListener} Failed to find current span in ConcurrentDictionary 00-8b5c2b0556c0964892e20625f30dc54f-d15d4347f811cb4e-01
Elastic.Apm: Error: {SerializerDiagnosticsListener} Failed to find current span in ConcurrentDictionary 00-8b5c2b0556c0964892e20625f30dc54f-d15d4347f811cb4e-01
fail: Elastic.Apm[0]
      {HttpConnectionDiagnosticsListener} Failed to find current span in ConcurrentDictionary 00-8b5c2b0556c0964892e20625f30dc54f-37f41deb5a297940-01
Elastic.Apm: Error: {HttpConnectionDiagnosticsListener} Failed to find current span in ConcurrentDictionary 00-8b5c2b0556c0964892e20625f30dc54f-37f41deb5a297940-01
fail: Elastic.Apm[0]
      {RequestPipelineDiagnosticsListener} Failed to find current span in ConcurrentDictionary 00-8b5c2b0556c0964892e20625f30dc54f-2db699c61329204d-01
Elastic.Apm: Error: {RequestPipelineDiagnosticsListener} Failed to find current span in ConcurrentDictionary 00-8b5c2b0556c0964892e20625f30dc54f-2db699c61329204d-01
info: APMSpanErrorRepro.TestGarbageService[0]
      Entity NSDVS was added
APMSpanErrorRepro.TestGarbageService: Information: Entity NSDVS was added
Elastic.Apm: Information: {RequestPipelineDiagnosticsListener} Received an CallElasticsearch.Start event from elasticsearch
info: Elastic.Apm[0]
      {RequestPipelineDiagnosticsListener} Received an CallElasticsearch.Start event from elasticsearch
info: Elastic.Apm[0]
      {HttpConnectionDiagnosticsListener} Received an SendAndReceiveHeaders.Start event from elasticsearch
Elastic.Apm: Information: {HttpConnectionDiagnosticsListener} Received an SendAndReceiveHeaders.Start event from elasticsearch
fail: Elastic.Apm[0]
      {HttpConnectionDiagnosticsListener} Failed to find current span in ConcurrentDictionary 00-8b5c2b0556c0964892e20625f30dc54f-61f29afcacc15c49-01
Elastic.Apm: Error: {HttpConnectionDiagnosticsListener} Failed to find current span in ConcurrentDictionary 00-8b5c2b0556c0964892e20625f30dc54f-61f29afcacc15c49-01
info: Elastic.Apm[0]
      {HttpConnectionDiagnosticsListener} Received an ReceiveBody.Start event from elasticsearch
Elastic.Apm: Information: {HttpConnectionDiagnosticsListener} Received an ReceiveBody.Start event from elasticsearch
info: Elastic.Apm[0]
      {SerializerDiagnosticsListener} Received an Deserialize.Start event from elasticsearch
Elastic.Apm: Information: {SerializerDiagnosticsListener} Received an Deserialize.Start event from elasticsearch
Elastic.Apm: Error: {SerializerDiagnosticsListener} Failed to find current span in ConcurrentDictionary 00-8b5c2b0556c0964892e20625f30dc54f-a6148309cecfd04b-01
fail: Elastic.Apm[0]
      {SerializerDiagnosticsListener} Failed to find current span in ConcurrentDictionary 00-8b5c2b0556c0964892e20625f30dc54f-a6148309cecfd04b-01
fail: Elastic.Apm[0]
      {HttpConnectionDiagnosticsListener} Failed to find current span in ConcurrentDictionary 00-8b5c2b0556c0964892e20625f30dc54f-61f29afcacc15c49-01
Elastic.Apm: Error: {HttpConnectionDiagnosticsListener} Failed to find current span in ConcurrentDictionary 00-8b5c2b0556c0964892e20625f30dc54f-61f29afcacc15c49-01
fail: Elastic.Apm[0]
      {RequestPipelineDiagnosticsListener} Failed to find current span in ConcurrentDictionary 00-8b5c2b0556c0964892e20625f30dc54f-2db699c61329204d-01
Elastic.Apm: Error: {RequestPipelineDiagnosticsListener} Failed to find current span in ConcurrentDictionary 00-8b5c2b0556c0964892e20625f30dc54f-2db699c61329204d-01
APMSpanErrorRepro.TestGarbageService: Information: Entity NSDVS was found
info: APMSpanErrorRepro.TestGarbageService[0]
      Entity NSDVS was found
```

Then nothing is reported to APM from this method. Note that the GET WeatherForecast/Get is reported.

If we change the Nest package version from 
```
<PackageReference Include="NEST" Version="7.10.1" /
```
to
```
<PackageReference Include="NEST" Version="7.10.0" /
```
    
Now everything works as expected.