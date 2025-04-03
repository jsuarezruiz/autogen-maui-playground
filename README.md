# AutoGen MAUI Playground

This project is designed to explore and experiment with the integration of AI capabilities, using **AutoGen** into .NET MAUI applications. It serves as a sandbox to test and create solutions that leverage cutting-edge AI tools.
Provides developers with a hands-on resource to learn about combining AutoGen with mobile and desktop app development.

**The sample use multiple AI agents to generate a mobile app from a simple prompt**.

![AutoGen MAUI Playground](images/autogen-maui-playground.gif)

### 🛠️ Setup

Clone the repository:

```
git clone https://github.com/jsuarezruiz/autogen-maui-playground.git
cd autogen-maui-playground
```

Install dependencies: Ensure you have all the required NuGet packages installed. Use the following command:

```
dotnet restore
```

Configure Azure OpenAI:

* Update the necessary configuration files to include your Azure OpenAI endpoint and API key.

Build and run the project:

```
dotnet build
dotnet run
```

### 💡 How It Works

* The user provides a prompt describing an application.
* AI agents, such as the SpecCreatorAgent and CodeCreatorAgent, process the input generating a detailed Spec and an App navigation diagram.
* Another AI agent generate a consolidated, well-structured, and formatted document based on the previous ones.
* An AI agent uses the generated Spec to generate the .NET MAUI App code.
* Middleware orchestrates the interactions between agents, resulting in structured specifications, designs, and generated code.
* Output is displayed in the .NET MAUI app interface further exploration.

### 🧩 Contributing

Contributions are welcome! If you'd like to contribute:

1. Fork the repository.
1. Create a new branch for your changes.
2. Submit a pull request with a clear description of the enhancements or fixes.

### 📄 License

This project is licensed under the MIT License.