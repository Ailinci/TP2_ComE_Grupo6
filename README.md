Realización
Para levantar el proyecto se usa Visual Studio 2022, ejecutando el archivo Program.cs.

CargarNuevoSuplemento()
Por un lado  en el que se pueden agregar los suplementos, y se pide que se ingrese el nombre, el margen de ganancia que se busca obtener y el precio de lista. El método lo guarda en una lista. Se puede hacer todas las veces que se requieran y se valida que en el campo de nombre se ingrese al menos 1 caracter, y en los campos numéricos que se ingresen solo números. Si estas condiciones no se dan, se vuelve a pedir que se ingrese un valor válido.


MostrarDetalleSuplementos()
Con este método se muestra al usuario la lista de todos los suplementos y sus atributos.


AgregarNuevoServicio()
Con este método se pueden crear los servicios, se solicita que se opte por uno de los dos tipos, y ambos comparten los atributos de nombre y duración, que se solicita en minutos. Las actividades grupales también solicitan que se agregue el número de participantes.


MostrarDetallesServicios()
Con este método se listan todos los servicios que se fueron agregando, independientemente del tipo de servicio que sea.


SalirFacturacion()
Con este método finalizamos la ejecución del programa y mostramos el total de todos los suplementos que se ingresaron con su valor final, y mostramos todos los servicios que se agregaron también con su valor final. Se realiza la sumatoria de ambos y se brinda el total facturado.


Test()
Se agregó también la ejecución del método TEST, que contiene un template de algunas respuestas básicas para poder probar el flujo principal de la aplicación sin tener que ir ingresando campo por campo. Este método funciona llamando a las ejecuciones reales, simulando el ingreso por consola de los datos que se solicitan.


