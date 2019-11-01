# Translations Against Humanity
Set of programs for translating and generating [Cards Against Humanity](https://cardsagainsthumanity.com/) cards.

![status](https://img.shields.io/badge/status-WiP-orange.svg)  [![version](https://img.shields.io/badge/version-0.1.0-green.svg)](https://semver.org) ![license](https://img.shields.io/badge/license-MIT-blue.svg)
## Table of contents

 - [Introduction](#introduction)
 - [Project Goals](#project-goals)
 - [Features](#features)
 - [Requirements](#requirements)
 - [Guide](#guide)
 - [Contribution](#contribution)
 - [Support](#support)
 - [License](#license)
## Introduction
[Cards Against Humanity](#https://cardsagainsthumanity.com/) is one of the most famous and controversial card game in the world. While there have been released localized versions of the game along with the fan translations of the game, a couple of problems could arise:

- CAH has not been translated to every language,
- Fan translations have a limited number of cards (around 500-600 cards compared to over 2000 official US cards)
- US version contain references to some events\celebrities, which could be not understood by people from other countries
- Making translations would be very hard, since there are over 2000 official cards and even more third-party cards and there isn't a simple way to work on translations in a bigger team, which could speed up the process of translation
- Online card generators do not offer the ability to generate compact version of cards, which are more space efficient (20 cards per page, based on free CAH version)

## Project goals
**Translations Against Humanity** (TAH) is a set of programs, which are aiming to offer:

- **Fast bulk translation** of the texts, which may speed up the translation process
- Making **corrections** to the translations
- Allowing **multiple users** to work on the same translation and preserve the history of changes using **Git Version Control**
- Generating CAH cards in compact PDF version with **20 cards per page**, ready for printing

## Features
- **Bulk Translator** (v1.0)
	- Translation of english card content to any available language using [Yandex.Translate](https://translate.yandex.com/)
	- Uses JSON files from [JSON Against Humanity](https://crhallberg.com/cah/)
	- Saves translations to JSON file
- **Proofreader** (comming soon)
- **Card Generator** (comming soon)

## Requirements

- [.NET Framework 4.8](https://dotnet.microsoft.com/download/dotnet-framework/net48)
- [Free API key](https://tech.yandex.com/translate/) for Yandex.Translate

## Guide

### Bulk Translator
1. Download JSON file with card texts from [this site](https://crhallberg.com/cah/).
2. Launch Bulk Translator and follow the instructions
3. Program will save a new JSON file with translated texts

## Contribution
1. Fork or clone this repo
2. Make changes
3. Create a [new pull request](https://github.com/janex-PL/TranslationsAgainstHumanity/compare)

## Support
If you have some questions, contact me via email **kliszczjan@gmail.com**.
## License
This project is licensed under MIT License - see the [LICENSE](https://github.com/janex-PL/TranslationsAgainstHumanity/LICENSE) file for details.
