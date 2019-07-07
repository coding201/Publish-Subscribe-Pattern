# Publisher/Subscriber Pattern
This is a C# .Net Core Console Application to demonstrate Publish/Subscriber pattern

#### Table of content
1. [Quick Start](#quick-start)
2. [Prerequisites](#prerequisites)
3. [Publisher/Subscriber pattern info](#publishersubscriber-pattern-info)
5. [TODOs](#todos)

## Quick Start
Several quick start options are available:
- [Download latest release](https://github.com/mosarsh/Publish-Subscribe-Pattern/archive/master.zip)
- Clone the repo: `git clone git@github.com:mosarsh/Publish-Subscribe-Pattern.git`

## Prerequisites
- Visual Studio
   
## Publisher/Subscriber pattern info
Publisher/Subscriber pattern is one of the variations of the Observer designer pattern. This is working very simple: publisher triggers a message and there are one or more Subscriber to particular message who listen to published message. Below image demonstrate how it works.

![](images/diagram1.png)

To achieve Publisher/Subscriber pattern has been used Event/Delegate. Here are the drawbacks of this approach:
1. For publishing different type of message there is need of creating different type of Publisher. For Example : Publisher<int> - for integer type, Publisher<string> - for string type.
2. Tight coupling bettwen Publisher and Subscriber. In this pattern Subscriber require to know Publisher as they subscribe to event of Publisher.
   
With this application you can create Subscribers for message type int and string by giving how many Subscriber you want to have for each of type message. See screenshot of app running below.

![](images/consoleapp.PNG)

## TODOs
1. To enhance application there is a need to create middle layer between publisher and subscriber in order to break tight coupling. Publisher and Subscriber shouldn't know each other. They both need to work with middle layer.
2. Comments needs to be added to the code.
3. Unit tests needs to be added.
