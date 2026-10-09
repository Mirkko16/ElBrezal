using System;
using System.Collections.Generic;
using System.Text;

namespace ElBrezal.Desktop.Helpers
{
    public static class OperacionProductosGridHelper
    {
        /// <summary>
        /// Busca una fila que contenga el producto indicado.
        /// Permite excluir una fila de la búsqueda.
        /// </summary>
        public static DataGridViewRow? BuscarFilaProducto(
            DataGridView dataGridViewProductos,
            DataGridViewColumn columnaArticulo,
            int productoId,
            DataGridViewRow? filaExcluir = null)
        {
            foreach (DataGridViewRow fila in dataGridViewProductos.Rows)
            {
                if (fila.IsNewRow || fila == filaExcluir)
                    continue;

                var valorArticulo =
                    fila.Cells[columnaArticulo.Name].Value;

                if (!int.TryParse(
                        valorArticulo?.ToString(),
                        out var productoIdFila))
                {
                    continue;
                }

                if (productoIdFila == productoId)
                    return fila;
            }

            return null;
        }

        /// <summary>
        /// Limpia los datos comerciales de una fila de producto.
        /// </summary>
        public static void LimpiarFila(
            DataGridViewRow fila,
            DataGridViewColumn columnaCantidad,
            DataGridViewColumn columnaArticulo,
            DataGridViewColumn columnaDescripcion,
            DataGridViewColumn columnaPrecio,
            DataGridViewColumn columnaImporte)
        {
            fila.Cells[columnaCantidad.Name].Value = null;
            fila.Cells[columnaArticulo.Name].Value = null;
            fila.Cells[columnaDescripcion.Name].Value = null;
            fila.Cells[columnaPrecio.Name].Value = null;
            fila.Cells[columnaImporte.Name].Value = null;
        }

        /// <summary>
        /// Posiciona el foco en la cantidad de una fila
        /// e inicia la edición de la celda.
        /// </summary>
        public static void PosicionarEnCantidad(
            DataGridView dataGridViewProductos,
            DataGridViewRow fila,
            DataGridViewColumn columnaCantidad)
        {
            dataGridViewProductos.ClearSelection();

            var celdaCantidad =
                fila.Cells[columnaCantidad.Name];

            dataGridViewProductos.CurrentCell = celdaCantidad;
            celdaCantidad.Selected = true;

            dataGridViewProductos.Focus();
            dataGridViewProductos.BeginEdit(true);
        }
    }
}
