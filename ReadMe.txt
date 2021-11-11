Caso de Uso para la empresa ficticia NorthWind
Historia de usuario: Crear orden de compra
Como usuario del sistema, deseo poder crear una orden de compra para solicitar productos del almac�n.

Caso de uso: Crear orden de compra

Datos de entrada
- Identificador del cliente
- Direcci�n de env�o
- Ciudad de env�o
- Pa�s de env�o
- C�digo Postal de env�o
- Lista de productos incluyendo:
- Identificador del producto
- Precio
- Cantidad

Flujo primario
1. El usuario env�a la solicitud "Crear orden de compra" con los datos de entrada.
2. El sistema valida los datos.
3. El sistema registra la orden de compra.
4. El sistema registra la acci�n "Crear orden de compra" con fines hist�ricos
5. Cuando el n�mero de productos de la orden sea mayor que 3, el sistema enviar� un correo de notificaci�n de "Orden especial creada" al administrador del sistema.
6. El sistema confirma al usuario que su solicitud ha sido procesada notific�ndole el n�mero de la orden creada.

Flujo alterno: Error de validaci�n.
1. El procesamiento de la solicitud es cancelado.
2. El error es registrado en la bit�cora de errores del sistema.
3. El sistema muestra el error al usuario.

Consideraciones
- NorthWind maneja 4 tipos de transporte de mercancias: Mar�timo, A�reo, Ferroviario y Terrestre. El tipo de transporte predeterminado es Terrestre.
- NorthWind maneja 2 formas para especificar descuentos: Mediante porcentaje y mediante cantidades absolutas. El descuento predeterminado de una compra es del 10%.

Validaciones
- El identificador del cliente es requerido y debe ser de 5 caracteres alfanumericos.
- La direcci�n de env�o es requerida. Debe ser de una longitud m�xima de 60 caracteres alfanum�ricos.
- La ciudad de env�o es requerida y debe tener una longitud m�nima de 3 y m�xima de 15 caracteres afanum�ricos.
- El pa�s de env�o es requerido y debe tener una longitud m�nima de 3 y m�xima de 15 caracteres afanum�ricos.
- El c�digo Postal es opcional con una longitud m�xima de 10 caracteres.
- Debe especificarse al menos un producto en la orden.
- De cada producto especificado en la orden, ser� requerido el identificador del producto, la cantidad y el precio.