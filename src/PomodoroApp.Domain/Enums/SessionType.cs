/// <summary>
/// Tipo de sesión Pomodoro según la técnica estándar.
/// Work = 25 min | ShortBreak = 5 min | LongBreak = 15-30 min
/// La duración exacta es configuración de la app, no del dominio.</summary>
public enum SessionType
{
    /// Sesión de trabajo enfocado (25 minutos en la técnica estándar)
    Work,

    /// Descanso corto entre pomodoros (5 minutos)
    ShortBreak,

    /// Descanso largo después de completar 4 pomodoros (15-30 minutos)
    LongBreak
}