<%@ Page Title="Reportes" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Reportes.aspx.cs" Inherits="TPORestobar.Reportes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-4">
        <h2 class="mb-4"><i class="fas fa-chart-line"></i> Panel de Reportes y Estadísticas</h2>

        <ul class="nav nav-tabs" id="reportesTab" role="tablist">
            <li class="nav-item" role="presentation">
                <button class="nav-tabs nav-link active" id="productos-tab" data-bs-toggle="tab" data-bs-target="#productos" type="button" role="tab">Más Vendidos</button>
            </li>
            <li class="nav-item" role="presentation">
                <button class="nav-tabs nav-link" id="recaudacion-tab" data-bs-toggle="tab" data-bs-target="#recaudacion" type="button" role="tab">Recaudación Diaria</button>
            </li>
            <li class="nav-item" role="presentation">
                <button class="nav-tabs nav-link" id="empleados-tab" data-bs-toggle="tab" data-bs-target="#empleados" type="button" role="tab">Rendimiento Mozos</button>
            </li>
        </ul>

        <div class="tab-content border border-top-0 p-4 bg-white rounded-bottom" id="reportesTabContent">
            
            <div class="tab-pane fade show active" id="productos" role="tabpanel">
                <h4>Ranking de Productos Más Demandados</h4>
                <p class="text-muted">Lista de los artículos con mayor cantidad de unidades vendidas históricamente.</p>
                <div class="table-responsive">
                    <asp:GridView ID="dgvProductosMasVendidos" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-hover mt-3">
                        <Columns>
                            <asp:BoundField DataField="Ranking" HeaderText="#" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="Producto" HeaderText="Producto / Plato" />
                            <asp:BoundField DataField="CantidadVendida" HeaderText="Unidades Vendidas" ItemStyle-HorizontalAlign="Right" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>

            <div class="tab-pane fade" id="recaudacion" role="tabpanel">
                <h4>Historial de Facturación por Día</h4>
                <p class="text-muted">Total acumulado de caja por cada fecha de trabajo.</p>
                <div class="table-responsive">
                    <asp:GridView ID="dgvRecaudacionDiaria" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-hover mt-3">
                        <Columns>
                            <asp:BoundField DataField="Fecha" HeaderText="Fecha" DataFormatString="{0:dd/MM/yyyy}" />
                            <asp:BoundField DataField="TotalRecaudado" HeaderText="Total Recaudado" DataFormatString="$ {0:N2}" ItemStyle-HorizontalAlign="Right" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>

            <div class="tab-pane fade" id="empleados" role="tabpanel">
                <h4>Ventas Totales por Empleado</h4>
                <p class="text-muted">Monto total facturado en pedidos despachados por cada mozo.</p>
                <div class="table-responsive">
                    <asp:GridView ID="dgvRendimientoMozos" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-hover mt-3">
                        <Columns>
                            <asp:BoundField DataField="Mozo" HeaderText="Nombre del Empleado" />
                            <asp:BoundField DataField="TotalFacturado" HeaderText="Total Facturado" DataFormatString="$ {0:N2}" ItemStyle-HorizontalAlign="Right" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>

        </div>
    </div>
</asp:Content>
