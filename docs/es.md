# Isometric Tiles — la vista en rombos del mapa

Isometric Tiles dibuja los mapas de tiles en ángulo, como una cuadrícula de rombos 2:1, de modo que los edificios y los árboles se levantan del suelo. Es una de las dos vistas de mapa del motor común Tile Rendering; la otra es Top-down Tiles. Los mismos mapas, eventos y partidas guardadas funcionan en ambas.

![La aldea de RPG Plus al mediodía en la vista isométrica: la plaza, las farolas, las casas, los aldeanos y el héroe en el camino; tras el borde del mapa, el fondo queda vacío.](assets/village-isometric.jpg)

## Qué cambia respecto a la vista superior

- **Casillas de rombo.** Cada casilla del mapa se dibuja como un rombo el doble de ancho que de alto. La cuadrícula lógica sigue siendo cuadrada: una casilla tiene los mismos cuatro vecinos que antes.
- **Objetos de pie.** Los edificios y demás objetos de varias casillas que el tileset marca como tales se dibujan como imágenes verticales o como varias caras planas, en lugar de tiles planos.
- **Los personajes** eligen la fila de sprites que corresponde a su dirección sobre la cuadrícula de rombos.
- **Al hacer clic** en el mapa se selecciona el rombo bajo el puntero; el editor de mapas RPG usa la misma regla.

![El mismo mapa de la aldea en ambas vistas: vista superior a la izquierda, isométrica a la derecha.](assets/same-map-two-projections.jpg)

Lo que no cambia: las reglas de caminar, las colisiones, los eventos, los combates, el guardado, la iluminación y la hora del día pertenecen al mod RPG y a Tile Rendering, y se comportan igual en ambas vistas.

## Limitaciones

- **Las teclas siguen la cuadrícula, no la pantalla.** Arriba y abajo (W/S, flechas) avanzan por una diagonal de la pantalla, izquierda y derecha por la otra, porque mueven al héroe una casilla de la cuadrícula cuadrada.
- **Se notan los bordes del mapa.** Cerca de una esquina se ve el fondo vacío más allá del borde del rombo, como en la imagen de arriba.
- **Los tilesets deben estar preparados.** Los objetos solo se ven de pie cuando el tileset los describe como grupos; los tiles normales se colocan planos sobre los rombos.

## Actívalo

En el esquema del juego (**Mods → Colecciones → el juego → Editar esquema**), incluye este mod y pon **Proyección del mapa** en **Isométrica**. El valor del ajuste `tile.renderer` es `isometric`:

```json
"settings": { "tile.renderer": "isometric" }
```

Para probarlo una vez sin cambiar el juego, arráncalo con `--tile-renderer=isometric` en la línea de comandos. RPG Plus ya incluye los dos renderizadores, así que basta con cambiar el ajuste.

## Si algo falla

1. **El mapa está vacío.** La **Proyección del mapa** del juego pide un renderizador que no está incluido; incluye este mod o elige otra proyección.
2. **El héroe camina en diagonal.** Así funcionan las teclas en esta vista (ver Limitaciones).
