# BotTranslaterDeepl

BotTranslaterDeepl is a C# application that integrates with the DeepL API to provide text translation and paraphrasing capabilities via a Telegram bot.

## Features

- **DeepL Integration**: Seamless connection to the DeepL translation and paraphrasing services.
- **Telegram Bot**: Allows users to translate and paraphrase text directly in Telegram.
- **Multi-language Support**: Supports translation between multiple languages.
- **Inline Buttons**: Interactive Telegram inline buttons for user-friendly navigation.

## Project Structure and Class Descriptions

- **Program.cs**  
  Entry point of the application. Initializes the Telegram bot and starts the message handling loop.

- **BotService.cs**  
  Contains the main logic for interacting with the Telegram Bot API and DeepL API. Handles sending and receiving messages, calling the translation/paraphrasing API, and managing user requests.

- **Handlers.cs**  
  Defines the event handlers for Telegram updates, such as processing user messages and callback queries from inline buttons.

- **InlineButtons.cs**  
  Manages the creation and handling of inline keyboard buttons shown to users within Telegram chats to facilitate language selection and command options.

- **Helpers.cs**  
  Contains utility methods used across the application, such as formatting text, parsing commands, or managing configuration.

## Requirements

- **.NET Framework**: Ensure you have the .NET Framework installed on your machine.
- **DeepL API Key**: Obtain an API key from [DeepL](https://www.deepl.com/pro) to use their translation and paraphrasing services.
- **Telegram Bot Token**: Create a Telegram bot and get its token from the [BotFather](https://t.me/BotFather).

## Usage

Run the bot application. It listens for Telegram messages and responds with translations or paraphrases according to user input and commands.
