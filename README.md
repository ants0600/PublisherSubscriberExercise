# README #

* This is the study case / exercise for implementing techniques of Publisher Subscriber.
* Most of the times, publisher-subscriber techniques use internet protocol to send / receive messages.
* One of many examples is the push notifications of mobile apps.
* In the mobile push notification, one instance acts as a publisher (sending message), and other instances act as subscribers (receiving message).
* In this study case, we don't use internet protocol.
* Instead, we simulate publisher subscriber using Windows Event Log functions.

### How to install

1) Clone this repository, use master branch as default.

2) Run powershell, then move current folder to the repository folder.
Ex:
cd "D:\pubsubsample\"

3) Then run this script: Set-ExecutionPolicy RemoteSigned

4) Answer "y" or "a" when prompted.

5) Afterwards, run script: install.ps1.
Ex:
&".\install.ps1"

6) then run 2 exe files created by msbuild (as we use Windows Form Application for demo purpose).

6a) Publisher, ex: 
D:\pubsubsample\src\PublisherUi\bin\Release\PublisherUi.exe

6b) Subscriber, ex:
D:\pubsubsample\src\SubscriberUi\bin\Release\SubscriberUi.exe

### References

* Pub sub theories

** Learn Microfoft: https://learn.microsoft.com/en-us/azure/architecture/patterns/publisher-subscriber

** Wikipedia: https://en.wikipedia.org/wiki/Publish%E2%80%93subscribe_pattern

* Windows Event
https://learn.microsoft.com/en-us/dotnet/api/system.diagnostics.eventlog.entrywritten?view=netframework-3.0

* Microfoft DDD
https://learn.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/ddd-oriented-microservice

* Autofac
https://youtu.be/9Pha-pKUqWA