Caso de Uso para la empresa ficticia NorthWind
Historia de usuario: Crear orden de compra
Como usuario del sistema, deseo poder crear una orden de compra para solicitar productos del almacén.

Caso de uso: Crear orden de compra

Datos de entrada
- Identificador del cliente
- Dirección de envío
- Ciudad de envío
- País de envío
- Código Postal de envío
- Lista de productos incluyendo:
- Identificador del producto
- Precio
- Cantidad

Flujo primario
1. El usuario envía la solicitud "Crear orden de compra" con los datos de entrada.
2. El sistema valida los datos.
3. El sistema registra la orden de compra.
4. El sistema registra la acción "Crear orden de compra" con fines históricos
5. Cuando el número de productos de la orden sea mayor que 3, el sistema enviará un correo de notificación de "Orden especial creada" al administrador del sistema.
6. El sistema confirma al usuario que su solicitud ha sido procesada notificándole el número de la orden creada.

Flujo alterno: Error de validación.
1. El procesamiento de la solicitud es cancelado.
2. El error es registrado en la bitácora de errores del sistema.
3. El sistema muestra el error al usuario.

Consideraciones
- NorthWind maneja 4 tipos de transporte de mercancias: Marítimo, Aéreo, Ferroviario y Terrestre. El tipo de transporte predeterminado es Terrestre.
- NorthWind maneja 2 formas para especificar descuentos: Mediante porcentaje y mediante cantidades absolutas. El descuento predeterminado de una compra es del 10%.

Validaciones
- El identificador del cliente es requerido y debe ser de 5 caracteres alfanumericos.
- La dirección de envío es requerida. Debe ser de una longitud máxima de 60 caracteres alfanuméricos.
- La ciudad de envío es requerida y debe tener una longitud mínima de 3 y máxima de 15 caracteres afanuméricos.
- El país de envío es requerido y debe tener una longitud mínima de 3 y máxima de 15 caracteres afanuméricos.
- El código Postal es opcional con una longitud máxima de 10 caracteres.
- Debe especificarse al menos un producto en la orden.
- De cada producto especificado en la orden, será requerido el identificador del producto, la cantidad y el precio.