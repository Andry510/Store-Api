namespace store.Messages
{
    public static class MessagesClass
    {
        // Mensajes de éxito
        public static string SuccessLogin() => "Inicio de sesión exitoso";
        public static string SuccessCreate() => "El registro ha sido creado exitosamente.";
        public static string SuccessGet() => "Los datos han sido obtenidos exitosamente.";
        public static string SuccessUpdate() => "El registro ha sido actualizado exitosamente.";
        public static string SuccessDelete() => "El registro ha sido eliminado exitosamente.";

        // Error
        public static string ErrorLogin() => "Correo electrónico o Contraseña incorrecta";
        public static string Error() => "Hubo un error. Intenta más tarde.";
        public static string ErrorUnauthorized() => "Acceso no autorizado.";
        public static string ErrorNotFound() => "No encontrado.";
        public static string ErrorConflict() => "Conflicto de datos.";
        public static string ErrorBadRequest() => "Solicitud inválida.";
        public static string ErrorInternalServer() => "Error en el servidor. Intenta más tarde.";


        // Mensajes relacionados con la existencia de elementos    
        public static string AlreadyExists() => "El elemento ya existe.";

        // Mensajes de validación
        public static string RequiredField(string fieldName) =>
           $"El campo '{fieldName}' es obligatorio.";

        public static string InvalidEmailField(string fieldName) =>
            $"El campo '{fieldName}' debe contener una dirección de correo electrónico válida.";

        public static string InvalidFormat(string fieldName) =>
            $"El formato del campo '{fieldName}' no es válido.";

        // Mensajes relacionados con la validación de tokens

        public static string TokenNotProvided() =>
            "Token no proporcionado.";

        public static string TokenInvalid() =>
            "Token inválido o expirado.";
    }
}
