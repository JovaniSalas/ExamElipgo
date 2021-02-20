Desarrollador: Ing. Jovani Salas Cruz

Nota: Había iniciado con idioma español pero al ver el requerimiento preferí poner nombre de los proyectos en ingles
1.- Configuramos la connectionStrings que está en el proyecto ApiZapatos 
	Para apuntar la instancia del gestor de Base de Datos en otras palabras 
	Debemos cambiar el Source
2-. Instalar todas las dependencias que hagan falta

3.- Configurar el orden de Compilado de cada proyecto
		Proyecto			Accion
	1.- ApiZapatos			Iniciar
	2.- BusinessEntities	Ninguna
	3.-	DataAccess			Ninguna
	4.- BusinessLogic		Ninguna
	5.- ShoeShop			Iniciar

4.- Compilar el toda la solución
5.- Abrir la consola de Administrador de Paquetes
6.- Elejir como proyecto Predeterminado "DataAccess"
7.- Escribir en la consola el siguiente comando "Enable-Migrations" y damos enter
8.- Una vez finalizado el proceso del paso 7, escribimos el  siguiente comando 
	en la consola "Add-Migration InicialTwoDbContext" y damos enter.
9.- Ahora que ha terminado el proceso del paso 8, escribimos el  siguiente comando 
	en la consola "Update-Database" y damos enter
10.- Hemos terminado ahora nuestra Base de datos se ha creado podemos para ello abrimos 
	 "SQL Server Managment Studio" para confirmarlo debe existir una BD con el nombre "ShoeShopBD"
11-. En el proyecto DataAccess hay una carpeta llamada "ScriptInserDatas" abrirla. 
12-. Existen dos archivos sql estos debes abrirlos en un nuevo query en el "SQL Server Managment Studio" 
	 y ejecutar uno por uno
	1.- Pripero ejecutamos el script del archivo  "Insert Stores.sql"
	2.- Ahora Ejecutamos el script del archivo "Insert Articles.sql"
13.- Ahora es momento de continuar con el paso 14.
14.- Ahora es momento de ejecutar nuevamente el paso 4.
15.- Proceder a dar Iniciar para que se ejecute toda nuestra solución
16.- Se nos debe abrir una ventana de navegador copiamos la url de esa ventana
17.- Detenemos nuestra aplicacion
18.- Verificar en el archivo App.Config del proyecto ShoeShopWF que el dominio 
	 de la URL así como el puerto sean iguales de ser diferentes debe de cambiar 
	 por el dominio que le mostro en el paso 16
19.- Aquí todo va bien ejecutamos el paso 15 de nuevo y estamos listos 
	 para utilizar la aplicación Windows Form

Nota: las URL del API son las siguientes:
https://localhost:44345/api/services/articles
https://localhost:44345/api/services/stores
https://localhost:44345/api/services/articles/stores/{store_id}
