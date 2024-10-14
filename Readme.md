# Proyecto C# con .NET y Angular

## Prerrequisitos

1. **Instalar .NET SDK**:
   - Asegúrate de tener instalado .NET SDK. Puedes descargarlo desde [aquí](https://dotnet.microsoft.com/download).

2. **Instalar Node.js y npm**:
   - Necesitas Node.js y npm para Angular. Puedes descargarlo desde [aquí](https://nodejs.org/).

3. **Instalar Angular CLI**:
   - Abre tu terminal y ejecuta el siguiente comando para instalar Angular CLI globalmente:
     ```sh
     npm install -g @angular/cli
     ```

4. **Instalar SQL Server**.

## Paso a Paso para Levantar la Aplicación

### 1. Conéctate al servidor de base de datos

1. Abre SQL Server Management Studio (SSMS)

2. Inicia sesión en el servidor de base de datos

3. Crea la base de datos (si aún no existe)

4. Inicia sesión en el servidor de base de datos

5. Verifica que los objetos se hayan creado

### 2. Configuración del Backend (C# con .NET)


1. Abrir el proyecto en Visual Studio:
   - Navega a la carpeta de tu proyecto .NET y abre el archivo `.sln` (solución) en Visual Studio.

2. Restaurar los paquetes NuGet:
   - En la barra de herramientas de Visual Studio, selecciona `Build` > `Restore NuGet Packages`.

3. Configura la cadena de conexión de la base de datos:
   - Asegúrate de que tu archivo `appsettings.json` tenga la cadena de conexión correcta para tu base de datos.

4. Actualizar la base de datos con las migraciones:
   - Abre la `Package Manager Console` en Visual Studio desde `Tools` > `NuGet Package Manager` > `Package Manager Console`.
   - Ejecuta el siguiente comando:
     ```sh
     Update-Database

5. Ejecutar el proyecto en el depurador de Visual Studio:
   - Presiona `F5` o selecciona `Debug` > `Start Debugging` en la barra de herramientas.

5. Instalar Visual Studio:
   - Descarga e instala Visual Studio desde [aquí](https://visualstudio.microsoft.com/downloads/).
   - Asegúrate de seleccionar la carga de trabajo **ASP.NET and web development** durante 


### 3.  Configuración del Frontend (Angular)
1.  Navega a la carpeta de tu proyecto Angular: cd /ruta/de/tu/proyecto/frontend

2. Instala las dependencias: npm install

3. Sirve la aplicación Angular: ng serve

### Resumen de Comandos

Restaurar paquetes: dotnet restore

Actualizar base de datos: dotnet ef database update

Levantar backend: dotnet run

Instalar dependencias: npm install

Levantar frontend: ng serve
