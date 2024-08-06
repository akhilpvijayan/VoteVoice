# VoteVoice

VoteVoice is an innovative application designed to allow users to create, manage, and participate in polls seamlessly. Built with a modern tech stack including Angular, .NET Core, and SQL Server, VoteVoice aims to provide a robust and user-friendly experience.

## Features

- **Create Polls**: Users can create polls with multiple options.
- **Vote on Polls**: Users can cast their votes on various polls.
- **Real-time Notifications**: Receive instant notifications when new votes are cast or polls are updated.
- **User Authentication**: Secure user authentication and authorization.
- **Results Display**: View real-time results of polls.

## Tech Stack

- **Frontend**: Angular
- **Backend**: .NET Core Web API
- **Database**: SQL Server
- **Real-time Communication**: SignalR
- **Message Queue**: RabbitMQ
- **Authentication**: JWT Authentication
- **Caching**: In-Memory Caching

## Installation

### Prerequisites

- Node.js and npm
- .NET Core SDK
- RabbitMQ
- SQL Server 2019 or above
- Visual Studio 2022 or above

### Steps

1. **Clone the repository**
    ```bash
    git clone https://github.com/akhilpvijayan/VoteVoice.git
    cd VoteVoice
    ```

2. **Install frontend dependencies**
    ```bash
    cd votevoice-client
    npm install
    ```

3. **Configure the backend**

    - Open `votevoice-server/votevoice.sin ` in Visual Studio 2022
    - Open `appsettings.json` in each service in `VoteVoice` directory and update the database connection string and other necessary configurations.
    - Open `ocelot.json` in the `GatewayService` directory and update the database connection string and other necessary configurations.

4. **Run the frontend**
    ```bash
    cd votevoice-client
    ng serve
    ```

## Usage

1. **Create an account**: Sign up for a new account.
2. **Login**: Log in with your credentials.
3. **Create Polls**: Navigate to the 'Create Poll' section to create a new poll.
4. **Vote**: Participate in available polls.
5. **View Results**: Check poll results in real-time.
6. **Receive Notifications**: Stay updated with real-time notifications for poll activities.

## Design Diagram

![image](https://github.com/user-attachments/assets/f998c816-8f52-40bd-aa9f-37f0e3dc5bcd)

## Contributing

We welcome contributions to VoteVoice. To contribute, please follow these steps:

1. Fork the repository.
2. Create a new branch (`git checkout -b feature-branch`).
3. Make your changes.
4. Commit your changes (`git commit -m 'Add new feature'`).
5. Push to the branch (`git push origin feature-branch`).
6. Create a pull request.

## License

This project is licensed under the APACHE 2.0 License. See the [LICENSE](LICENSE) file for details.

## Contact

For any inquiries or support, please contact us at [akhilpv88.apg@gmail.com].

---

Thank you for using VoteVoice! We hope it brings great value to your polling needs.




