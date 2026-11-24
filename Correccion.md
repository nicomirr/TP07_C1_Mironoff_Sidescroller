# Corrección, Trabajo Práctico N°07: Side Scroller 2D

- **Alumno/a:** Mironoff (Nicolas Ivan Mironoff)
- **Entrega:** `TP07_C1_Mironoff_Sidescroller`
- **Materia:** Programación con Motores de Videojuegos I
- **Nota TP07:** 9


## 1. Checklist de requisitos

### Bloque único, Side Scroller 2D

| #   | Requisito | Estado | Evidencia |
|-----|-----------|--------|-----------|
| R1  | Repositorio nuevo con nombre `TP07_C1_Apellido_Titulo` | ✓ | `nicomirr/TP07_C1_Mironoff_Sidescroller`, repo nuevo y propio del TP |
| R2  | Proyecto de Unity con el mismo nombre | ✓ | La carpeta del proyecto es la raíz del repo (`TP07_C1_Mironoff_Sidescroller`). Ojo: `ProjectSettings/ProjectSettings.asset:16` tiene `productName: The Door` |
| R3  | El personaje va a derecha e izquierda | ✓ | `Assets/Scripts/Player/PlayerMovement.cs:25`, llamado desde `PlayerController.FixedUpdate` (`PlayerController.cs:133`) |
| R4  | El personaje puede disparar | ✓ | `Assets/Scripts/Player/PlayerThrow.cs:47`, que se dispara con el evento de animación `PlayerAnimationEvents.OnThrowFinishedAnimEvent` |
| R5  | El personaje puede saltar | ✓ | `Assets/Scripts/Player/PlayerJump.cs:39` con coyote time y corte de salto (`PlayerJump.cs:48`) |
| R6  | Enemigos u obstáculos que quitan vida | ✓ | `Assets/Scripts/Enemy/Controllers/EnemyCombatController.cs:11` (`IDamageProvider`), daño de contacto en `GreenSlimeCombatData.asset` (1), `SnakeCombatData.asset` (2) y `FishCombatData.asset` (2); se aplica en `PlayerDamageHandler.TryDamage` |
| R7  | Se eliminan con más de 2 disparos, tienen vida y barra de vida arriba (Canvas World) | Parcial | `SnakeHealthData.asset` tiene `_maxHealth: 4` (4 disparos) y cumple. `GreenSlimeHealthData.asset` tiene `_maxHealth: 2` con piedra de daño 1, o sea que muere con 2 disparos, no con más de 2. La barra existe (`HealthCanvas` en World Space en los dos prefabs), pero `UIHealth.Start` la deja en `alpha = 0` (`Assets/Scripts/UI/UIHealth.cs:38`) y solo se ve 1 segundo después de cada golpe (`UIHealthData.asset`, `_displayTime: 1`) |
| R8  | ParticleSystem al destruir al enemigo | ✓ | `Assets/Scripts/Enemy/EnemyDeath.cs:21`, prefabs `GreenSlimeDeathParitcles.prefab` y `SnakeDeathParitcles.prefab` |
| R9  | Pickables | ✓ | `Assets/Scripts/Pickables/Pickable.cs`, `HealthPotion.prefab` cura a través de `PlayerHealthEffect` |
| R10 | Sonido en todas las acciones | Parcial | Música de gameplay ✓ (`MUS_Game.mp3` en `Game.unity`). Saltar ✓ (`PlayerController.cs:196`, `PlayerJumpAudio.asset`). Agarrar coleccionable ✓ (`SFX_Potion.mp3` en `HealthPotion.prefab`, `Pickable.cs:49`). Eliminar enemigo ✓ (`SFX_SlimeDeath.mp3` y `SFX_SnakeDeath.mp3` en los prefabs de partículas, `ParticleEffect.cs:16`). Disparar ✗: no hay ningún clip en `HandleThrow`, `HandleThrowFinished` ni `PlayerThrow.Throw`, solo suena el impacto contra algunas superficies con `SurfaceSoundPlayer`. Al perder ✗: `PlayerDeathHandler.HandleDeath` no reproduce ningún clip y `PlayerDoll.prefab` no tiene `AudioSource` |
| R11 | Volumen desde Settings conectado a un AudioMixer | ✓ | `Assets/Scripts/UI/UIVolumeButtons.cs:74` llama a `Assets/Scripts/Audio/AudioManager.cs:23-24` (`_audioMixer.SetFloat`), y hay 31 `AudioSource` ruteados a grupos de `AudioMixer.mixer` |
| R12 | Usa ScriptableObject | ✓ | 49 clases `*So` en `Assets/Scripts/Data/`, con assets en `Assets/Data/` (por ejemplo `PlayerConfig.asset`, `Rock.asset`) que se leen en los constructores |
| R13 | Power ups o modificación de jugabilidad | ✓ | `Assets/Scripts/Player/Powerups/PlayerInvincibilityPowerUp.cs:25`, `InvincibilityPow.prefab` en `Game.unity`; en modo invencible, el contacto desactiva al enemigo (`PlayerCollisionHandler.cs:38`) |
| R14 | Personaje animado | ✓ | `Assets/Art/Animations/Player/PlayerController.controller`, con parámetros por hash en `AnimationLibrary` y `PlayerAnimations` |
| R15 | Escena de menú principal y de Gameplay | ✓ | `Assets/Scenes/MainMenu.unity` y `Assets/Scenes/Game.unity` en Build Settings |

## 2. Cumplimiento de Pautas de Cursada

| ID | Pauta | Estado | Evidencia |
|----|-------|--------|-----------|
| P1 | Unity 6000.3.21f1 | ✓ | `ProjectSettings/ProjectVersion.txt` dice `6000.3.21f1` |
| P2 | Repo público en GitHub | ✓ | El repositorio es público |
| P3 | Nombre del repo `TPxx_Cn_Apellido_Titulo` | ✓ | `TP07_C1_Mironoff_Sidescroller` |
| P4 | Código en inglés | ✓ | Clases, métodos, campos, enums y escenas en inglés en los scripts que leí; solo los mensajes de `Debug.LogError` y los comentarios están en español |
| P5 | Un repo por TP, sin branches | ✓ | Solo existe `main` |

## 3. Estructura de carpetas

| Carpeta esperada | Encontrada | Observación |
|------------------|------------|-------------|
| `Art/Animations/` | ✓ | |
| `Art/Audio/` | ✗ | El audio está en `Assets/Audio/` (raíz de Assets) |
| `Art/Fonts/` | ✓ | |
| `Art/Sprites/` | ✓ | |
| `Art/Materials/` | No aplica | No hay `.mat` propios; el `PhysicsMaterial2D` está en `Assets/Physics/Materials/` |
| `Data/` | ✓ | Todos los `.asset` de ScriptableObject están ahí |
| `Prefabs/` | ✓ | La subcarpeta `Prefabs/Chekpoint/` tiene un error de tipeo |
| `Scenes/` | ✓ | |
| `Scripts/` | ✓ | Organizado por feature (`Player/`, `Enemy/`, `UI/`, `Data/`, `Core/`...), no por `Game/` y `Ui/` |

Archivos o carpetas mal ubicados:

- `Assets/Audio/` (música, SFX y `AudioMixer.mixer`): va en `Assets/Art/Audio/`.
- `Assets/Physics/Materials/No friction.physicsMaterial2D`: es una carpeta extra, podría ir en `Assets/Art/Materials/`.
- `Assets/Settings/` (URP y `URP2DSceneTemplate.unity`), `Assets/TextMesh Pro/` y `Assets/Scripts/Input/GameControls.cs` (lo genera el Input System) son de paquetes o generados, no los revisé.

## 4. Qué le falta

- Sonido al disparar (`PlayerController.cs:230`) y al perder (`PlayerDeathHandler.cs:47`).
- Subir `_maxHealth` del GreenSlime a 3 o más en `GreenSlimeHealthData.asset`, para que haga falta más de 2 disparos.
- Decidir si la barra de vida se tiene que ver siempre: hoy solo aparece 1 segundo después de cada golpe.
- Usar `_data.RespawnTime` en `EnemyLifecycleHandler` en lugar del `10` fijo.
- Mover a `FixedUpdate` el seteo de velocidad de los enemigos.
- Proteger los accesos a diccionarios (`AudioPlayer`, `PlayerFootsteps`) con `TryGetValue`.

## 5. Hallazgos de código

### Error (2)
- `Assets/Scripts/Player/PlayerController.cs:230` No hay sonido al disparar (R10).
- `Assets/Scripts/Management/PlayerDeathHandler.cs:47` No hay sonido al perder (R10).

### Bug (2)
- `Assets/Scripts/Enemy/EnemyLifecycleHandler.cs:46` `WaitForSeconds(10)` ignora `_data.RespawnTime` (que vale 15 en el asset).
- `Assets/Scripts/Player/PlayerController.cs:262` `DamageSFX` suena aunque `TryDamage` rechace el daño (Invincible o ya Damaged).

### Warning (12)
- `Assets/Scripts/Player/PlayerController.cs:302` `OnHealthChanged.Invoke` sin `?.`.
- `Assets/Scripts/Player/PlayerHealth.cs:13` Comparación de floats con `==`.
- `Assets/Scripts/Player/PlayerFacing.cs:20` `direction == 0` con un valor de analógico.
- `Assets/Scripts/Animations/AnimationHandler.cs:23` Comparación de floats con `==`.
- `Assets/Scripts/Player/PlayerFootsteps.cs:27` Acceso al diccionario sin `TryGetValue`.
- `Assets/Scripts/Audio/AudioPlayer.cs:27` Acceso al diccionario sin `TryGetValue`.
- `Assets/Scripts/Enemy/EnemyBrain.cs:56` La FSM setea la velocidad del Rigidbody desde `Update`.
- `Assets/Scripts/Checkpoints/Checkpoint.cs:48` El trigger no filtra por jugador.
- `Assets/Scripts/Throwables/ThrowableFactory.cs:22` El `return` en el constructor deja `_parent` sin asignar.
- `Assets/Scripts/UI/UIMenuManager.cs:64` String mágico `"Gamepad"`.
- `Assets/Scripts/Parallax/ParallaxBackground.cs:19` `Camera.main` en `LateUpdate`.
- `Assets/Scripts/Input/GlobalInputs.cs:39` A `GameControls` nunca le hacés `Dispose`.

### Suggestion (10)
- `Assets/Scripts/Player/PlayerJump.cs:14` Campos y property sin uso.
- `Assets/Scripts/Throwables/Throwable.cs:54` Código comentado y `_collider` sin uso.
- `Assets/Scripts/Audio/AudioHandler.cs:6` Clase sin uso, con `_pauseNotifier` que nunca se asigna.
- `Assets/Scripts/Core/Audio/AudioCategory.cs:8` Valores del enum sin uso.
- `Assets/Scripts/Player/PlayerGroundCheck.cs:7` Clases sin namespace.
- `Assets/Scripts/Data/SceneTransitions/SceneToLoadSo.cs:9` Properties en camelCase.
- `Assets/Scripts/Pickables/Pickable.cs:31` `if` sin efecto.
- `Assets/Scripts/Boat/HarborBell.cs:12` `_MovementStopperGameObject` no sigue el naming del resto.
- `Assets/Scripts/Enemy/EnemyLifecycleHandler.cs:33` Polling de `activeSelf` en `Update`.
- `Assets/Scripts/Enemy/StateMachine/EnemyStateMachine.cs:46` `ResetState` sin `Exit()`.

## 6. Recomendaciones

1. Agregá sonido de disparo en `PlayerController.HandleThrowFinished` y sonido de derrota en `PlayerDeathHandler.HandleDeath` (R10).
2. Subí `_maxHealth` del GreenSlime a 3 o más y pensá si conviene mostrar la barra de vida siempre (R7).
3. Corregí los 2 bugs: usá `_data.RespawnTime` y mové el `DamageSFX` adentro de `PlayerDamageHandler.TryDamage`.
4. Mové el seteo de velocidad de los enemigos a `FixedUpdate` y reemplazá los accesos directos a diccionarios por `TryGetValue`.
5. Limpiá el código sin uso (`AudioHandler`, valores de `AudioCategory`, campos de `PlayerJump`, el bloque comentado de `Throwable`) y mové `Assets/Audio/` a `Assets/Art/Audio/`.
