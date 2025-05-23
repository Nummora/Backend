# Backend

# Convención de Commits y Nombres de Ramas
## 1. Introduccin
Este documento define la convención estandarizada para la escritura de mensajes de *commit* y la
nomenclatura de ramas en el proyecto. El objetivo principal es garantizar la **claridad**, **consistencia** y
**trazabilidad** del trabajo realizado, facilitando la colaboración entre desarrolladores y la automatización de
procesos como *CI/CD*, generación de *changelogs*, o seguimiento de historias de usuario (HU).
## 2. Convencin para Commits
Cada mensaje de commit debe seguir la siguiente estructura:
```
<tipo>(<scope>): <mensaje del commit>
```
### Tipos permitidos:
| Tipo | Uso previsto |
|-----------|------------------------------------------------------------------------------|
| `feat` | Nueva funcionalidad o componente agregado al sistema |
| `fix` | Correccin de errores o *bugs* |
| `chore` | Tareas de mantenimiento sin impacto directo en la lógica del negocio |
| `hotfix` | Corrección urgente de errores en producción |
| `refactor`| Cambios en el código que no afectan su funcionalidad (mejoras internas) |
### Ejemplos:
```
feat(auth): agregar autenticación con JWT
fix(user): corregir validación de email en formulario
chore(ci): actualizar flujo de integración continua
hotfix(login): evitar error 500 al loguearse sin contraseña
refactor(api): optimizar estructura de controladores
```
> El uso de `scope` es obligatorio y representa el mdulo, componente o funcionalidad afectada.
## 3. Convención para Nombres de Ramas
Cada rama debe ser nombrada siguiendo la siguiente estructura:
```
<tipo>/<idHU>-<nombre-claro-de-la-rama>
```
### Tipos permitidos:
Los mismos definidos en los commits:
- `feat`
- `fix`
- `chore`
- `hotfix`
- `refactor`
### Detalles:
- `<idHU>` hace referencia al identificador de la historia de usuario o tarea en el sistema de gestión (por
ejemplo: Jira, Azure DevOps, Trello, etc.).
- `<nombre-claro-de-la-rama>` debe estar en **kebab-case** (minúsculas y separado por guiones).
### Ejemplos:
```
feat/hu-102-login-con-google
fix/hu-110-correccion-navbar-responsive
hotfix/hu-999-urgente-crash-en-produccion
refactor/hu-120-limpiar-servicios-inyectados
chore/hu-001-configurar-eslint
```
## 4. Beneficios
- Mejora el historial de cambios del repositorio.
- Facilita la revisión de código (*code review*).
- Permite generación automatizada de changelogs.
- Vinculación directa con herramientas de gestión de proyectos.
- Mejora la colaboración y entendimiento entre miembros del equipo.
## 5. Consideraciones Finales
- Todos los miembros del equipo deben adherirse estrictamente a esta convención.
- Las *pull requests* deben mantener consistencia con esta estructura.
- Esta guía puede evolucionar según las necesidades del equipo o el proyecto.
