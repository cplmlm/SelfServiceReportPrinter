# SelfServiceReportPrinter

This is a self-service report printer project, designed to provide a solution for handling report printing functionality on self-service terminals.

## Project Structure

- **Commands**: Contains classes implementing the command pattern to handle operations within the application.
  - `QueryCommand.cs`: Implements the `ICommand` interface, used to encapsulate execution and validation logic for commands.
  - `RelayCommand.cs`: A generic implementation of the `ICommand` interface, used for more flexible command binding.

- **ViewModel**: Contains view model classes to implement the MVVM pattern and handle UI logic.
  - `KeyPressCommunityToolkitViewModel.cs`: A view model implemented using `CommunityToolkit.Mvvm`, handling key press logic.
  - `KeyPressViewModel.cs`: A view model based on the traditional `INotifyPropertyChanged` implementation, handling key press logic.

- **MainWindow.xaml**: Main window interface design file.
- **MainWindow.xaml.cs**: Code-behind for the main window, inherited from the `Window` class.

- **App.xaml**: Application XAML definition file.
- **App.xaml.cs**: Code-behind for the application, inherited from the `Application` class.

## Features

- Decouples UI and business logic using the command pattern.
- Supports data binding and UI interaction through the MVVM pattern.
- Provides two different view model implementations: one based on `CommunityToolkit.Mvvm` and another based on traditional `INotifyPropertyChanged`.

## Usage Instructions

1. Open the `SelfServiceReportPrinter.sln` solution file.
2. Build and run the project.
3. In the main window, you can use the numeric keypad to enter a card number and perform operations using the clear and delete functions.

## Contribution Guidelines

Code contributions and project improvements are welcome. Please follow these steps:

1. Fork the project.
2. Create a new branch.
3. Commit your changes.
4. Submit a Pull Request.

## License

This project uses the MIT License. For details, please refer to the [LICENSE](LICENSE) file.