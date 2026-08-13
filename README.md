# Sistema de Punto de Venta

Aplicación de escritorio para la gestión de ventas e inventario, desarrollada en **C# con Windows Forms**. El sistema permite administrar artículos, consultar información de productos, registrar ventas y visualizar estadísticas.

## Características

* 🔐 Inicio de sesión de usuarios.
* 📦 Alta, modificación, consulta y eliminación de artículos.
* 🔎 Consulta de productos por:

  * Clave
  * Producto
  * Precio
  * Stock
* 🛒 Registro de ventas.
* 💳 Selección del tipo de pago.
* 🧾 Cálculo automático del total de la venta.
* 📊 Visualización de gráficas.
* 📁 Lectura y escritura de información mediante archivos Excel.
* 💾 Registro de ventas y productos.

## Tecnologías utilizadas

* **C#**
* **Windows Forms**
* **.NET Framework 4.8**
* **Visual Studio**
* **ClosedXML**
* **Microsoft Excel / archivos `.xlsx`**

## Estructura principal

```text
PuntodeVenta/
├── PuntodeVenta.sln
├── PuntodeVenta/
│   ├── Form1.cs
│   ├── FrmLogin.cs
│   ├── FrmVenta.cs
│   ├── FrmGrafica.cs
│   ├── frmAgregar.cs
│   ├── Modificar.cs
│   ├── Bajas.cs
│   ├── CArticulo.cs
│   ├── CClave.cs
│   ├── CPrecio.cs
│   ├── CStock.cs
│   ├── ArticulosBs.cs
│   ├── Venta.cs
│   ├── Graficas.cs
│   ├── articulos.xlsx
│   ├── ventas.xlsx
│   └── login.txt
└── README.md
```

## Requisitos

Para ejecutar el proyecto se necesita:

* Windows.
* Visual Studio compatible con **.NET Framework 4.8**.
* .NET Framework 4.8.
* Las dependencias del proyecto, incluidas en `packages.config`.

## Instalación

1. Clona o descarga el repositorio.

2. Abre el archivo:

```text
PuntodeVenta.sln
```

3. Abre el proyecto con Visual Studio.

4. Restaura los paquetes NuGet necesarios.

5. Compila la solución.

6. Ejecuta el proyecto.

## Inicio de sesión

El sistema utiliza el archivo `login.txt` para validar las credenciales.

En una instalación inicial, se crea automáticamente un usuario de prueba:

```text
Usuario: admin
Contraseña: 12345
```

> Se recomienda cambiar este mecanismo de autenticación antes de utilizar el sistema en un entorno real, ya que actualmente las credenciales se almacenan en texto plano.

## Gestión de artículos

Desde el menú principal es posible administrar los productos mediante las opciones de agregar, modificar, eliminar y consultar artículos.

Los datos de los artículos se manejan mediante:

```text
articulos.xlsx
```

El sistema utiliza la biblioteca **ClosedXML** para leer y modificar los archivos Excel.

## Registro de ventas

El módulo de ventas permite seleccionar artículos, agregarlos al carrito y calcular automáticamente el total.

También permite seleccionar el tipo de pago y registrar la operación en:

```text
ventas.xlsx
```

Cada venta puede almacenar información como:

* Total de la venta.
* Fecha y hora.
* Tipo de pago.

## Gráficas

El proyecto incluye un módulo para visualizar información relacionada con las ventas mediante gráficas.

## Dependencias

Entre las principales dependencias utilizadas se encuentran:

* `ClosedXML`
* `DocumentFormat.OpenXml`
* `ExcelNumberFormat`
* `Irony`
* `SixLabors.Fonts`

Las versiones y referencias completas se encuentran en el archivo del proyecto y en `packages.config`.

## Notas

Este proyecto está diseñado principalmente como una aplicación académica o de gestión básica. Para utilizarlo en producción sería recomendable implementar:

* Base de datos SQL.
* Contraseñas cifradas.
* Gestión de usuarios y permisos.
* Validaciones más robustas.
* Manejo de errores y respaldos.
* Control de inventario más completo.
* Reportes de ventas.
* Configuración externa para las rutas de archivos.


