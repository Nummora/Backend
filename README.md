# Backend

# Commit and Branch Naming Convention

## 1. Introduction
This document defines the standardized convention for writing *commit* messages and naming branches in the project. The main goal is to ensure **clarity**, **consistency**, and **traceability** of the work done, making collaboration among developers easier and enabling automation of processes such as *CI/CD*, changelog generation, and tracking of user stories (US).

## 2. Commit Convention
Each commit message must follow the following structure:
<type>(<scope>): <commit message>

### Allowed Types:
| Type      | Intended Use |
|-----------|------------------------------------------------------------|
| `feat`    | New functionality or component added to the system         |
| `fix`     | Bug fixes                                                  |
| `chore`   | Maintenance tasks with no direct impact on business logic  |
| `hotfix`  | Urgent bug fixes in production                             |
| `refactor`| Code changes that do not affect functionality (internal improvements) |

### Examples:
feat(auth): add JWT authentication
fix(user): fix email validation in form
chore(ci): update continuous integration flow
hotfix(login): avoid 500 error when logging in without password
refactor(api): optimize controller structure

> The use of `scope` is mandatory and represents the module, component, or affected functionality.

## 3. Branch Naming Convention
Each branch must be named following the structure:
<type>/<usId>-<clear-branch-name>


### Allowed Types:
The same ones defined for commits:
- `feat`
- `fix`
- `chore`
- `hotfix`
- `refactor`

### Details:
- `<usId>` refers to the user story or task identifier in the management system (e.g., Jira, Azure DevOps, Trello, etc.).
- `<clear-branch-name>` must be in **kebab-case** (lowercase and hyphen-separated).

### Examples:
feat/us-102-login-with-google
fix/us-110-fix-responsive-navbar
hotfix/us-999-urgent-crash-in-production
refactor/us-120-clean-injected-services
chore/us-001-configure-eslint


## 4. Benefits
- Improves the repository's change history.
- Facilitates code review.
- Enables automated changelog generation.
- Direct integration with project management tools.
- Enhances collaboration and understanding among team members.

## 5. Final Considerations
- All team members must strictly adhere to this convention.
- *Pull requests* must be consistent with this structure.
- This guide may evolve based on the team's or project's needs.
