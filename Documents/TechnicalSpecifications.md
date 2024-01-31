# <h1 align="center">Technical Specifications</h1>

<p align="right">created : 10/07/2023<br>last modified : 10/01/2024</p>

<details>
<summary>Table Of Content</summary>

- [Introduction](#introduction)

</details>

# Introduction

## Overview

As stated in the Functionnal Specifications, this project has for objective to create a small software for sawmills to help them optimise the process of sawing wood and minimise their losses by providing an algorithm which given certain parameters will output a detailed and optimised sawing process.

This software will also propose a management tool for stocks and clients' orders to ensure the best possible optimisation of the sawing processes.

## Technical Requirements

To ensure that our software will be widely used, it will be compatible with the most common operating systems both on desktop computers and mobile phones.

### Desktop

| OS | OS Version |
| ---- | ---- |
| MacOS | 14+ |
| Windows | 7+ |

### Mobile

| OS | OS Version |
| ---- | ---- |
| Android | 13+ |
| IOS | 17+ |

## Developement Environment

Considering the size of this project and the timeframe in which it will be conducted, there will be two different environments in which it will be developed.

| OS | MacOS Sonoma 14.2.1 | Windows 10 |
| ---- | ---- | ---- |
| Processor | Apple M1 | Intel i7 6700 |
| RAM | 8 Gb | 8 Gb |
| Graphic Processor | Apple M1 | Nvidia GTX 1660ti |

## Constraints

Time - The timeframe of the project maybe wide but as always we need to stay alert on deadlines and milestone to ensure progression and delivery on time

There are no specific constraints other than time on this project, 

# Solution

## Technologies

For this project, we will use Unity and C# to create our software. The choice came down to Unity because it allows us to easily integrate a User Interface and export the software in different formats compatible with our required operating systems (Computer or Mobile). Furthermore, I personally had quite a bit of experience with Unity, thus avoiding the need to learn how to use it, saving time and allowing faster development.

We will use Unity version 2021.3.24f1 as it is an LTS (Long Term Support) version compatible with both MacOS and Windows.

We will use Visual Studio Code (on Mac) and Visual Studio Community (on Windows) as IDEs.

## Conventions

### File

folder structure:
- Folder for all scripts
- Folder for all UI
- File names in PascalCase

### Coding

variables -> snake_case
Functions -> PascalCase

### Comments

Each function needs at least one comment explaining its purpose.
- functions
- complex formulas

## Architecture Diagram

### Desktop

![Desktop_Architecture](../Documents/Images/TechnicalSpecifications/ArchitectureDiagramDesktop.png)

### Mobile

![Mobile_Architecture](../Documents/Images/TechnicalSpecifications/ArchitectureDiagramMobile.png)

## Algorithm

inputs:
same as funtional

List for saw cuts following the algorithm

side 1 -> eleminate until remaining 80%

side 2 -> eleminate until remaining 80% or until reach side 1 last cut

side 3 -> 
- calculate remaining
- if repetition -> divide
- else -> minus the wanted one then divide (and save)

side 4 ->
- calculate remaining
- if repetition -> divide
- else -> minus the wanted one then use saved one and fill corners

outputs:
 same as functional

## Stock / Clients' orders Management

where do you save (File/DB)? and how ?

## Error Handling

what error do the software handle and how ?

Wrong Input
- Brigs out new window
- Stop the algorithm

## Alerts

What are they, how do they work ?

# Further Considerations

## Accessibility

## Risks & Assumptions

# Sucess Evaluation

## Metrics

## User Feedback

# Work

## Prioritisation

## Milestones

# End Mater

## References

- [Functional Specifications](../Documents/FunctionalSpecifications.md)

## Glossary

### Operating System

### Unity

### C#

### User Interface

### LTS or Long Term Support
