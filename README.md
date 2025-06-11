<h1>
  Sufficit.Telephony.EventsPanel.Core
  <a href="[https://github.com/sufficit/sufficit](https://github.com/sufficit/sufficit)"><img src="[https://avatars.githubusercontent.com/u/66928451?s=200&v=4](https://avatars.githubusercontent.com/u/66928451?s=200&v=4)" alt="Sufficit Logo" width="80" align="right"></a>
</h1>

[![NuGet](https://img.shields.io/nuget/v/Sufficit.Telephony.EventsPanel.Core.svg)]([https://www.nuget.org/packages/Sufficit.Telephony.EventsPanel.Core/](https://www.nuget.org/packages/Sufficit.Telephony.EventsPanel.Core/))

## 📖 About the Project

`Sufficit.Telephony.EventsPanel.Core` is the core library for the Sufficit Real-time Telephony Events Panel. It contains the essential business logic, data models, and interfaces required to build and interact with a live dashboard displaying telephony activities.

This library is not a UI framework itself but provides the foundational components for both backend services (which process and push events) and frontend applications (which consume and display events).

### ✨ Key Features

* Core models for telephony events (e.g., `PanelEvent`, `ChannelStatus`, `QueueInfo`).
* DTOs for communication between backend and frontend (e.g., via SignalR).
* Business logic for interpreting and enriching raw telephony events.
* Interfaces for services that manage the state of the events panel.

## 🚀 Getting Started

This is a core library and is meant to be consumed by other projects. Install it as a dependency via NuGet.

### 📦 NuGet Package

Install the package via the .NET CLI or the NuGet Package Manager Console.

**.NET CLI:**

    dotnet add package Sufficit.Telephony.EventsPanel.Core

**Package Manager Console:**

    Install-Package Sufficit.Telephony.EventsPanel.Core

> **Note for Developers:** The code samples below use 4-space indentation rather than fenced code blocks (```). This is intentional to prevent rendering issues in certain environments and ensure the raw text can be copied cleanly.

## 🛠️ Usage

This library is used by referencing its models and services in your backend event processors or frontend view models.

**Example of a model from the library:**

    using Sufficit.Telephony.EventsPanel.Core;

    public class DashboardViewModel
    {
        public List<ChannelStatus> ActiveChannels { get; set; } = new();

        // This method would be called by a SignalR client or other real-time service
        public void UpdateChannelState(ChannelStatus newStatus)
        {
            var existingChannel = ActiveChannels.FirstOrDefault(c => c.UniqueID == newStatus.UniqueID);
            if (existingChannel != null)
            {
                // Update properties
                existingChannel.State = newStatus.State;
                existingChannel.Duration = newStatus.Duration;
            }
            else
            {
                ActiveChannels.Add(newStatus);
            }
        }
    }

## 🤝 Contributing

Contributions are greatly appreciated. Please follow the standard fork and pull request workflow.

## 📄 License

Distributed under the MIT License. See `LICENSE` for more information.

## 📧 Contact

Sufficit - [contato@sufficit.com.br](mailto:contato@sufficit.com.br)

Project Link: [https://github.com/sufficit/sufficit-telephony-eventspanel-core](https://github.com/sufficit/sufficit-telephony-eventspanel-core)