# Gemini PowerToys

Launch Gemini directly from PowerToys Run with one command.

This project adds a lightweight PowerToys Run plugin that lets you type a prompt in the launcher and open Gemini with it preloaded in your browser. It is built for quick context switching and faster AI prompting without leaving your keyboard.

## Why this project exists

PowerToys Run is fast, keyboard-first, and built for quick actions. This plugin turns that flow into a simple Gemini shortcut:

- type `gemini`
- optionally add a prompt
- the plugin copies your text to the clipboard
- it opens Gemini in your browser
- it pastes the prompt and submits it

## Features

- Launch Gemini from PowerToys Run
- Open the Gemini homepage with no text
- Send a prompt directly to Gemini from the launcher
- Copy the prompt to the clipboard before opening the browser
- Paste the prompt into the active browser page automatically
- Works well as a personal productivity shortcut for frequent Gemini use

## Usage

```text
gemini
```

Open the Gemini homepage.

```text
gemini explain how async streams work in .NET
```

Open Gemini and paste that prompt into the page.

## Quick start

### Requirements

- Windows 10 or later
- .NET SDK 9.0+
- PowerToys installed
- PowerToys Run enabled
- Local PowerToys Wox infrastructure assemblies available in your environment

### Build

```bash
dotnet build "Community.PowerToys.Run.Plugin.Gemini.csproj" -nologo
```

The compiled plugin is produced under:

```text
bin\Gemini\
```

## Project structure

```text
.
├── Community.PowerToys.Run.Plugin.Gemini.csproj
├── Community.PowerToys.Run.Plugin.Gemini.sln
├── Gemini.LocalBuild.csproj
├── README.md
├── main.cs
├── plugin.json
├── Icon/
├── Properties/
└── bin/
```

## How it works

When you trigger the plugin:

1. The launcher passes the query text to the plugin
2. The plugin trims it and stores it as the prompt
3. If the prompt is not empty, it copies it to the clipboard
4. It opens `https://gemini.google.com/app` in the default browser
5. A short delay is used before sending the paste command and Enter key

This creates a smooth bridge from PowerToys Run into Gemini.

## Notes for local development

This repository includes a local build setup because the full PowerToys repo is not embedded in the same folder structure. The project references local PowerToys Wox assemblies from the environment, which makes standalone development possible without the full source tree.

## License

This project does not currently include a license file. If you plan to share or distribute it publicly, adding an open-source license is recommended.

## Contributing

Pull requests are welcome. If you improve compatibility, add robustness, or refine the UX, feel free to contribute.

---

A small plugin for turning your command launcher into a faster Gemini workflow.
