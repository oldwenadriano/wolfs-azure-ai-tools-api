# Wolf's Azure AI Tools API

An ASP.NET Core Web API that powers an AI portfolio chatbot using Azure OpenAI and a markdown-based knowledge retrieval system.

## Overview

This project demonstrates a production-style AI application architecture built with .NET and Azure OpenAI.

The API receives chat requests from a Blazor frontend, retrieves relevant knowledge from structured markdown files, builds a context-aware prompt, and returns an AI-generated response.

## Key Features

- ASP.NET Core Web API backend
- Azure OpenAI integration
- Markdown-based knowledge base
- Keyword-based retrieval
- Context-aware AI responses
- Server-side conversation orchestration
- GitHub-safe configuration using User Secrets

## Architecture

```text
Blazor Frontend
    ↓
ASP.NET Core Web API
    ↓
KnowledgeContextService
    ↓
Markdown Knowledge Base
    ↓
Azure OpenAI