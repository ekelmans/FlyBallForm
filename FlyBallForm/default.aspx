<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="FlyBallForm.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        td
            {border-left:1px solid black;
            border-top:1px solid black;
            text-align:  center;
            background-color: white;
        }
        .table-style1 {
            width: 100%;
            border-collapse: collapse;
            border: medium solid #000000; 
            font-family: Arial, Helvetica, sans-serif; 
            font-size: large; 
            font-weight: bold
        }
        .btnCol-style {
            width: 5%;
        }        
        .lblCol-style {
            text-align: right;
            width: 15%;
        }
        .dataCol-style {
            text-align: left;
            width: 30%;
        }
        .ddlResultaat-style {
            width: 110px;
            font-family: Arial, Helvetica, sans-serif; 
            font-size: large; 
            font-weight: bold
        }
        .ddlPunten-style {
            width: 50px;
            font-family: Arial, Helvetica, sans-serif; 
            font-size: large; 
            font-weight: bold;
        }
        .ChkBoxClass input {
            width:25px; 
            height:25px;
        }

        .btnTab-style {
            width:100%;
            height:25px;
            font-family: Arial, Helvetica, sans-serif; 
            font-size: large; 
        }
        .lblHondCol1-style {
            text-align: right;
            width: 10%;
        }
        .lblHond-style {
            text-align: center;
            width: 15%;
        }
        .commentcol-style {
            text-align: center;
        }
        .tijdenpuntencol-style {
            width:15%;
        }
        .TijdTextbox-style {
            width: 90px;
            font-family: Arial, Helvetica, sans-serif;
            font-size: large;
            font-weight: bold;
            text-align: center;
        }

    </style>
</head>
<body bgcolor="black">
    <form id="form1" runat="server">

        <asp:FormView ID="FormView1" runat="server" AllowPaging="False" DataSourceID="SqlDataSource1" width="100%" DataKeyNames="RaceID" >
            <ItemTemplate>
                <table align="center" class="table-style1" >
                    <tr>
                        <td class="btnCol-style" rowspan="3">
                            <asp:ImageButton ID="btnRing1" runat="server" ImageUrl="~/images/1.png" OnClick="btnRing1_Click" />
                        </td>
                        <td class="lblCol-style">Lokatie:</td>
                        <td class="dataCol-style">
                            <asp:Label ID="WDLabel" runat="server" Text='<%# Bind("WD") %>' />
                        </td>
                        <td class="lblCol-style">RaceID:</td>
                        <td class="dataCol-style">
                            <asp:Label ID="RaceIDLabel" runat="server" Text='<%# Bind("RaceID") %>' />
                        </td>
                        <td class="btnCol-style" rowspan="3">
                            <asp:ImageButton ID="btnPlus" runat="server" ImageUrl="~/images/Plus.png" OnClick="btnPlus_Click"  />
                        </td>
                    </tr>
                    <tr>
                        <td class="lblCol-style">Dagdeel:</td>
                        <td class="dataCol-style">
                            <asp:Label ID="DagdeelLabel" runat="server" Text='<%# Bind("Dagdeel") %>' />
                        </td>
                        <td class="lblCol-style">Ring: </td>
                        <td class="dataCol-style">
                            <asp:Label ID="RingNummerLabel" runat="server" Text='<%# Bind("RingNummer") %>' />
                        </td>
                    </tr>
                    <tr>
                        <td class="lblCol-style">Prog.Nr: </td>
                        <td class="dataCol-style">
                            <asp:Label ID="ProgrammaNrLabel" runat="server" Text='<%# Bind("ProgrammaNr") %>' />
                        </td>
                        <td class="lblCol-style">Type: </td>
                        <td class="dataCol-style">
                            <asp:Label ID="RTNLabel" runat="server" Text='<%# Bind("RTN") %>' />
                        </td>
                    </tr>
                    <tr>
                        <td class="btnCol-style">&nbsp;</td>
                        <td class="lblCol-style">Divisie: </td>
                        <td class="dataCol-style">
                            <asp:Label ID="DivisieNummerLabel" runat="server" Text='<%# Bind("DivisieNummer") %>' />
                        </td>
                        <td class="lblCol-style">Race: </td>
                        <td class="dataCol-style">
                            <asp:Label ID="RaceNrLabel" runat="server" Text='<%# Bind("RaceNr") %>' />
                        </td>
                        <td class="btnCol-style"></td>
                    </tr>
                    <tr>
                        <td class="btnCol-style" rowspan="3">
                            <asp:ImageButton ID="btnRing2" runat="server" ImageUrl="~/images/2.png" OnClick="btnRing2_Click" />
                        </td>
                        <td class="lblCol-style">Tijd: </td>
                        <td class="dataCol-style">
                            <asp:Label ID="DTLabel" runat="server" Text='<%# Bind("DT", "{0:HH:mm}") %>' />
                        </td>
                        <td class="lblCol-style">Gelopen:</td>
                        <td class="dataCol-style">
                            <asp:Label ID="GelopenLabel" runat="server" Text='<%# Bind("Gelopen") %>' />
                        </td>
                        <td class="btnCol-style" rowspan="3">
                            <asp:ImageButton ID="btnMin" runat="server" ImageUrl="~/images/Minus.png" OnClick="btnMin_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td class="lblCol-style">Rood: </td>
                        <td class="dataCol-style">
                            <asp:Label ID="RoodLabel" runat="server" Text='<%# Bind("Rood") %>' />
                        </td>
                        <td class="lblCol-style">Blauw: </td>
                        <td class="dataCol-style">
                            <asp:Label ID="BlauwLabel" runat="server" Text='<%# Bind("Blauw") %>' />
                        </td>
                    </tr>
                    <tr>
                        <td class="lblCol-style">Finale: </td>
                        <td class="dataCol-style">
                            <asp:Label ID="FinaleLabel" runat="server" Text='<%# Bind("Finale") %>' />
                        </td>
                        <td class="lblCol-style">Herkansing: </td>
                        <td class="dataCol-style">
                            <asp:Label ID="HerkansingLabel" runat="server" Text='<%# Bind("Herkansing") %>' />
                        </td>
                    </tr>

                </table>

            </ItemTemplate>
        </asp:FormView>

        <div style="width: 100%; overflow: hidden; background-color:white;" >
            <div style="width:40%; float: left;">  
                <asp:Button ID="btnRed" runat="server" Text=""  CssClass="btnTab-style" BackColor="#F78181" OnClick="btnRed_Click" />
            </div>
            <div style="width:40%; float: right;">
                <asp:Button ID="btnBlue" runat="server" Text="" CssClass="btnTab-style" BackColor="#819FF7" OnClick="btnBlue_Click" />
            </div>
        </div>
        
        <div style="width: 100%; overflow: hidden; background-color:white;">
            <asp:MultiView ID="MultiView1" ActiveViewIndex="0" runat="server">
                <asp:View ID="View1" runat="server">
                    <asp:FormView ID="FormView2" runat="server" DataSourceID="SqlDataSource4" width="100%" DataKeyNames="RaceID" >
                        <ItemTemplate>
                            <table align="center" class="table-style1" >
                                <tr>
                                    <td class="lblHondCol1-style"><%--<asp:Label ID="RaceIDLabel" runat="server" Text='<%# Bind("RaceID") %>' />--%></td>
                                    <td class="lblHond-style">Hond1</td>
                                    <td class="lblHond-style">Hond2</td>
                                    <td class="lblHond-style">Hond3</td>
                                    <td class="lblHond-style">Hond4</td>
                                    <td class="lblHond-style">Hond5</td>
                                    <td class="lblHond-style">Hond6</td>
                                </tr>
                                <tr>
                                    <td class="lblHondCol1-style">Naam:</td>
                                    <td class="lblHond-style"> <asp:Label ID="Hond1Label" runat="server" Text='<%# Bind("RH1") %>' /> </td>
                                    <td class="lblHond-style"> <asp:Label ID="Hond2Label" runat="server" Text='<%# Bind("RH2") %>' /> </td>
                                    <td class="lblHond-style"> <asp:Label ID="Hond3Label" runat="server" Text='<%# Bind("RH3") %>' /> </td>
                                    <td class="lblHond-style"> <asp:Label ID="Hond4Label" runat="server" Text='<%# Bind("RH4") %>' /> </td>
                                    <td class="lblHond-style"> <asp:Label ID="Hond5Label" runat="server" Text='<%# Bind("RH5") %>' /> </td>
                                    <td class="lblHond-style"> <asp:Label ID="Hond6Label" runat="server" Text='<%# Bind("RH6") %>' /> </td>
                                </tr>
                                <tr>
                                    <td class="lblHondCol1-style">Sprong:</td>
                                    <td class="lblHond-style"> <asp:Label ID="Hond1SHLabel" runat="server" Text='<%# Bind("RH1SH") %>' /> </td>
                                    <td class="lblHond-style"> <asp:Label ID="Hond2SHLabel" runat="server" Text='<%# Bind("RH2SH") %>' /> </td>
                                    <td class="lblHond-style"> <asp:Label ID="Hond3SHLabel" runat="server" Text='<%# Bind("RH3SH") %>' /> </td>
                                    <td class="lblHond-style"> <asp:Label ID="Hond4SHLabel" runat="server" Text='<%# Bind("RH4SH") %>' /> </td>
                                    <td class="lblHond-style"> <asp:Label ID="Hond5SHLabel" runat="server" Text='<%# Bind("RH5SH") %>' /> </td>
                                    <td class="lblHond-style"> <asp:Label ID="Hond6SHLabel" runat="server" Text='<%# Bind("RH6SH") %>' /> </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:FormView>

                    <asp:FormView ID="FormView6" runat="server" DataSourceID="SqlDataSource4" width="100%" DataKeyNames="RaceID" >
                        <ItemTemplate>
                            <table align="center" class="table-style1" >
                                <tr>
                                    <td class="lblHondCol1-style">Opmerking:</td>
                                    <td class="commentcol-style" colspan="6"> 
                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("RText") %>' /> 
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:FormView>

                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource2" class="table-style1" AutoGenerateEditButton="False" butt DataKeyNames="HeatID" >
                        <RowStyle Width="10%" />
                        <Columns>
                            <asp:BoundField DataField="HeatID" HeaderText="HeatID" SortExpression="HeatID" Visible="false"/>

                            <asp:TemplateField HeaderText="Heat" SortExpression="HeatNr">
                                <EditItemTemplate>
                                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("HeatNr") %>'></asp:Label>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("HeatNr") %>'></asp:Label>
                                    &nbsp;
                                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("RaceID") %>'></asp:Label>
                                    &nbsp;
                                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("HeatID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="H1" SortExpression="Hond1">
                                <EditItemTemplate>
                                    <asp:CheckBox ID="CheckBox1" runat="server" Checked='<%# Bind("Hond1") %>' CssClass="ChkBoxClass" />
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="CheckBox1" runat="server" Checked='<%# Bind("Hond1") %>' Enabled="false" CssClass="ChkBoxClass"/>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="H2" SortExpression="Hond2">
                                <EditItemTemplate>
                                    <asp:CheckBox ID="CheckBox2" runat="server" Checked='<%# Bind("Hond2") %>' CssClass="ChkBoxClass" />
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="CheckBox2" runat="server" Checked='<%# Bind("Hond2") %>' Enabled="false" CssClass="ChkBoxClass"/>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="H3" SortExpression="Hond3">
                                <EditItemTemplate>
                                    <asp:CheckBox ID="CheckBox3" runat="server" Checked='<%# Bind("Hond3") %>' CssClass="ChkBoxClass" />
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="CheckBox3" runat="server" Checked='<%# Bind("Hond3") %>' Enabled="false" CssClass="ChkBoxClass"/>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="H4" SortExpression="Hond4">
                                <EditItemTemplate>
                                    <asp:CheckBox ID="CheckBox4" runat="server" Checked='<%# Bind("Hond4") %>' CssClass="ChkBoxClass" />
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="CheckBox4" runat="server" Checked='<%# Bind("Hond4") %>' Enabled="false" CssClass="ChkBoxClass"/>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="H5" SortExpression="Hond5">
                                <EditItemTemplate>
                                    <asp:CheckBox ID="CheckBox5" runat="server" Checked='<%# Bind("Hond5") %>' CssClass="ChkBoxClass" />
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="CheckBox5" runat="server" Checked='<%# Bind("Hond5") %>' Enabled="false" CssClass="ChkBoxClass"/>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="H6" SortExpression="Hond6">
                                <EditItemTemplate>
                                    <asp:CheckBox ID="CheckBox6" runat="server" Checked='<%# Bind("Hond6") %>' CssClass="ChkBoxClass" />
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="CheckBox6" runat="server" Checked='<%# Bind("Hond6") %>' Enabled="false" CssClass="ChkBoxClass"/>
                                </ItemTemplate>
                            </asp:TemplateField>


                            <asp:TemplateField HeaderText="Resultaat" SortExpression="ResultaatID">
                                <EditItemTemplate>
<%--                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("ResultaatID") %>'></asp:TextBox>--%>
                                    <asp:DropDownList ID="ddlResultaat" runat="server" DataValueField="ResultaatID" SelectedValue='<%# Bind("ResultaatID") %>' CssClass="ddlResultaat-style">
                                        <asp:ListItem Value="1" >Win</asp:ListItem>
                                        <asp:ListItem Value="2" >Lose</asp:ListItem>
                                        <asp:ListItem Value="3" >Tie</asp:ListItem>
                                        <asp:ListItem Value="4" >Lose NT</asp:ListItem>
                                        <asp:ListItem Value="5" >Cancelled</asp:ListItem>
                                        <asp:ListItem Value="6" >To be run</asp:ListItem>
                                        <asp:ListItem Value="7" >UBT</asp:ListItem>
                                    </asp:DropDownList>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <%--<asp:Label ID="Label1" runat="server" Text='<%# Bind("ResultaatID") %>'></asp:Label>--%>
                                    <asp:DropDownList ID="ddlResultaat" runat="server" DataValueField="ResultaatID" SelectedValue='<%# Bind("ResultaatID") %>' Enabled="false" CssClass="ddlResultaat-style">
                                        <asp:ListItem Value="1" >Win</asp:ListItem>
                                        <asp:ListItem Value="2" >Lose</asp:ListItem>
                                        <asp:ListItem Value="3" >Tie</asp:ListItem>
                                        <asp:ListItem Value="4" >Lose NT</asp:ListItem>
                                        <asp:ListItem Value="5" >Cancelled</asp:ListItem>
                                        <asp:ListItem Value="6" >To be run</asp:ListItem>
                                        <asp:ListItem Value="7" >UBT</asp:ListItem>
                                    </asp:DropDownList>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Punten" SortExpression="Punten">
                                <EditItemTemplate>
                                    <asp:DropDownList ID="ddlPunten" runat="server" DataValueField="Punten" SelectedValue='<%# Bind("Punten") %>' CssClass="ddlPunten-style">
                                        <asp:ListItem Value="0" >0</asp:ListItem>
                                        <asp:ListItem Value="1" >1</asp:ListItem>
                                        <asp:ListItem Value="2" >2</asp:ListItem>
                                    </asp:DropDownList>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:DropDownList ID="ddlPunten" runat="server" DataValueField="Punten" SelectedValue='<%# Bind("Punten") %>' Enabled="false" CssClass="ddlPunten-style">
                                        <asp:ListItem Value="0" >0</asp:ListItem>
                                        <asp:ListItem Value="1" >1</asp:ListItem>
                                        <asp:ListItem Value="2" >2</asp:ListItem>
                                    </asp:DropDownList>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Tijd" SortExpression="Tijd" >
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Tijd") %>' type="number" CssClass="TijdTextbox-style"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("Tijd") %>' CssClass="TijdTextbox-style"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:CommandField ShowEditButton="True" />

                        </Columns>
                    </asp:GridView>
                </asp:View>
                <asp:View ID="View2" runat="server">
                    <asp:FormView ID="FormView3" runat="server" DataSourceID="SqlDataSource4" width="100%" DataKeyNames="RaceID" >
                        <ItemTemplate>
                            <table align="center" class="table-style1" >
                                <tr>
                                    <td class="lblHondCol1-style"><%--<asp:Label ID="RaceIDLabel" runat="server" Text='<%# Bind("RaceID") %>' />--%></td>
                                    <td class="lblHond-style">Hond1</td>
                                    <td class="lblHond-style">Hond2</td>
                                    <td class="lblHond-style">Hond3</td>
                                    <td class="lblHond-style">Hond4</td>
                                    <td class="lblHond-style">Hond5</td>
                                    <td class="lblHond-style">Hond6</td>
                                </tr>
                                <tr>
                                    <td class="lblHondCol1-style">Naam:</td>
                                    <td class="lblHond-style"> <asp:Label ID="Hond1Label" runat="server" Text='<%# Bind("BH1") %>' /> </td>
                                    <td class="lblHond-style"> <asp:Label ID="Hond2Label" runat="server" Text='<%# Bind("BH2") %>' /> </td>
                                    <td class="lblHond-style"> <asp:Label ID="Hond3Label" runat="server" Text='<%# Bind("BH3") %>' /> </td>
                                    <td class="lblHond-style"> <asp:Label ID="Hond4Label" runat="server" Text='<%# Bind("BH4") %>' /> </td>
                                    <td class="lblHond-style"> <asp:Label ID="Hond5Label" runat="server" Text='<%# Bind("BH5") %>' /> </td>
                                    <td class="lblHond-style"> <asp:Label ID="Hond6Label" runat="server" Text='<%# Bind("BH6") %>' /> </td>
                                </tr>
                                <tr>
                                    <td class="lblHondCol1-style">Sprong:</td>
                                    <td class="lblHond-style"> <asp:Label ID="Hond1SHLabel" runat="server" Text='<%# Bind("BH1SH") %>' /> </td>
                                    <td class="lblHond-style"> <asp:Label ID="Hond2SHLabel" runat="server" Text='<%# Bind("BH2SH") %>' /> </td>
                                    <td class="lblHond-style"> <asp:Label ID="Hond3SHLabel" runat="server" Text='<%# Bind("BH3SH") %>' /> </td>
                                    <td class="lblHond-style"> <asp:Label ID="Hond4SHLabel" runat="server" Text='<%# Bind("BH4SH") %>' /> </td>
                                    <td class="lblHond-style"> <asp:Label ID="Hond5SHLabel" runat="server" Text='<%# Bind("BH5SH") %>' /> </td>
                                    <td class="lblHond-style"> <asp:Label ID="Hond6SHLabel" runat="server" Text='<%# Bind("BH6SH") %>' /> </td>
                                </tr>
                            </table>

                        </ItemTemplate>
                    </asp:FormView>

                    <asp:FormView ID="FormView4" runat="server" DataSourceID="SqlDataSource4" width="100%" DataKeyNames="RaceID" >
                        <ItemTemplate>
                            <table align="center" class="table-style1" >
                                <tr>
                                    <td class="lblHondCol1-style">Opmerking:</td>
                                    <td class="commentcol-style" colspan="6"> 
                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("BText") %>' /> 
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:FormView>

                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource3" class="table-style1" AutoGenerateEditButton="False" butt DataKeyNames="HeatID" >
                        <RowStyle Width="10%" />
                        <Columns>
                            <asp:BoundField DataField="HeatID" HeaderText="HeatID" SortExpression="HeatID" Visible="false"/>

                            <asp:TemplateField HeaderText="Heat" SortExpression="HeatNr">
                                <EditItemTemplate>
                                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("HeatNr") %>'></asp:Label>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("HeatNr") %>'></asp:Label>
                                    &nbsp;
                                    <asp:Label ID="Label6" runat="server" Text='<%# Bind("RaceID") %>'></asp:Label>
                                    &nbsp;
                                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("HeatID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="H1" SortExpression="Hond1">
                                <EditItemTemplate>
                                    <asp:CheckBox ID="CheckBox1" runat="server" Checked='<%# Bind("Hond1") %>' CssClass="ChkBoxClass" />
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="CheckBox1" runat="server" Checked='<%# Bind("Hond1") %>' Enabled="false" CssClass="ChkBoxClass"/>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="H2" SortExpression="Hond2">
                                <EditItemTemplate>
                                    <asp:CheckBox ID="CheckBox2" runat="server" Checked='<%# Bind("Hond2") %>' CssClass="ChkBoxClass" />
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="CheckBox2" runat="server" Checked='<%# Bind("Hond2") %>' Enabled="false" CssClass="ChkBoxClass"/>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="H3" SortExpression="Hond3">
                                <EditItemTemplate>
                                    <asp:CheckBox ID="CheckBox3" runat="server" Checked='<%# Bind("Hond3") %>' CssClass="ChkBoxClass" />
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="CheckBox3" runat="server" Checked='<%# Bind("Hond3") %>' Enabled="false" CssClass="ChkBoxClass"/>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="H4" SortExpression="Hond4">
                                <EditItemTemplate>
                                    <asp:CheckBox ID="CheckBox4" runat="server" Checked='<%# Bind("Hond4") %>' CssClass="ChkBoxClass" />
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="CheckBox4" runat="server" Checked='<%# Bind("Hond4") %>' Enabled="false" CssClass="ChkBoxClass"/>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="H5" SortExpression="Hond5">
                                <EditItemTemplate>
                                    <asp:CheckBox ID="CheckBox5" runat="server" Checked='<%# Bind("Hond5") %>' CssClass="ChkBoxClass" />
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="CheckBox5" runat="server" Checked='<%# Bind("Hond5") %>' Enabled="false" CssClass="ChkBoxClass"/>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="H6" SortExpression="Hond6">
                                <EditItemTemplate>
                                    <asp:CheckBox ID="CheckBox6" runat="server" Checked='<%# Bind("Hond6") %>' CssClass="ChkBoxClass" />
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="CheckBox6" runat="server" Checked='<%# Bind("Hond6") %>' Enabled="false" CssClass="ChkBoxClass"/>
                                </ItemTemplate>
                            </asp:TemplateField>


                            <asp:TemplateField HeaderText="Resultaat" SortExpression="ResultaatID">
                                <EditItemTemplate>
<%--                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("ResultaatID") %>'></asp:TextBox>--%>
                                    <asp:DropDownList ID="ddlResultaat" runat="server" DataValueField="ResultaatID" SelectedValue='<%# Bind("ResultaatID") %>' CssClass="ddlResultaat-style">
                                        <asp:ListItem Value="1" >Win</asp:ListItem>
                                        <asp:ListItem Value="2" >Lose</asp:ListItem>
                                        <asp:ListItem Value="3" >Tie</asp:ListItem>
                                        <asp:ListItem Value="4" >Lose NT</asp:ListItem>
                                        <asp:ListItem Value="5" >Cancelled</asp:ListItem>
                                        <asp:ListItem Value="6" >To be run</asp:ListItem>
                                        <asp:ListItem Value="7" >UBT</asp:ListItem>
                                    </asp:DropDownList>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <%--<asp:Label ID="Label1" runat="server" Text='<%# Bind("ResultaatID") %>'></asp:Label>--%>
                                    <asp:DropDownList ID="ddlResultaat" runat="server" DataValueField="ResultaatID" SelectedValue='<%# Bind("ResultaatID") %>' Enabled="false" CssClass="ddlResultaat-style">
                                        <asp:ListItem Value="1" >Win</asp:ListItem>
                                        <asp:ListItem Value="2" >Lose</asp:ListItem>
                                        <asp:ListItem Value="3" >Tie</asp:ListItem>
                                        <asp:ListItem Value="4" >Lose NT</asp:ListItem>
                                        <asp:ListItem Value="5" >Cancelled</asp:ListItem>
                                        <asp:ListItem Value="6" >To be run</asp:ListItem>
                                        <asp:ListItem Value="7" >UBT</asp:ListItem>
                                    </asp:DropDownList>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Punten" SortExpression="Punten">
                                <EditItemTemplate>
                                    <asp:DropDownList ID="ddlPunten" runat="server" DataValueField="Punten" SelectedValue='<%# Bind("Punten") %>' CssClass="ddlPunten-style">
                                        <asp:ListItem Value="0" >0</asp:ListItem>
                                        <asp:ListItem Value="1" >1</asp:ListItem>
                                        <asp:ListItem Value="2" >2</asp:ListItem>
                                    </asp:DropDownList>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:DropDownList ID="ddlPunten" runat="server" DataValueField="Punten" SelectedValue='<%# Bind("Punten") %>' Enabled="false" CssClass="ddlPunten-style">
                                        <asp:ListItem Value="0" >0</asp:ListItem>
                                        <asp:ListItem Value="1" >1</asp:ListItem>
                                        <asp:ListItem Value="2" >2</asp:ListItem>
                                    </asp:DropDownList>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Tijd" SortExpression="Tijd" >
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Tijd") %>' type="number" CssClass="TijdTextbox-style"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("Tijd") %>' CssClass="TijdTextbox-style"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:CommandField ShowEditButton="True" />

                        </Columns>
                    </asp:GridView>
                </asp:View>
            </asp:MultiView>

        </div>


        <asp:SqlDataSource 
            ID="SqlDataSource1" 
            runat="server" 
            ConnectionString="<%$ ConnectionStrings:FlyFormConnectionString %>" 
            SelectCommand="SELECT * FROM [FlyFormProgramma] WHERE ([RingNummer] = @RingNummer) ORDER BY [Dagdeel] DESC, [RingNummer], [ProgrammaNr]"
            >
            <SelectParameters>
                <asp:SessionParameter DefaultValue="1" Name="RingNummer" SessionField="RingNummer" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>

        <asp:SqlDataSource
            ID="SqlDataSource2"
            runat="server"
            ConnectionString="<%$ ConnectionStrings:FlyFormConnectionString %>"
           SelectCommand="
SELECT  [HeatID]
        ,[RaceID]
        ,[HeatNr]
        ,[BaanKleurID]
        ,[TeamID]
        ,[Tijd]
        ,[ResultaatID]
        ,isnull([Punten], 0) as Punten
        ,[Hond1]
        ,[Hond2]
        ,[Hond3]
        ,[Hond4]
        ,[Hond5]
        ,[Hond6]
FROM    [FlyFormHeat] 
WHERE   [RaceID] = @RaceID 
AND BaankleurID = 1 
ORDER BY [BaanKleurID], [HeatNr]" 
            UpdateCommand="
update [FlyForm].[dbo].[FlyFormHeat]
set             Tijd                    = @Tijd
                               ,ResultaatID= @ResultaatID
                               ,Punten                = @Punten
                               ,Hond1                 = @Hond1
                               ,Hond2                 = @Hond2
                               ,Hond3                 = @Hond3
                               ,Hond4                 = @Hond4
                               ,Hond5                 = @Hond5
                               ,Hond6                 = @Hond6
where  HeatID                 = @HeatID">
            <SelectParameters>
                <asp:ControlParameter ControlID="FormView1" DefaultValue="11736" Name="RaceID" PropertyName="SelectedValue" Type="Int32" />
            </SelectParameters>
            <UpdateParameters>
                <asp:Parameter Name="Tijd" DbType="Decimal"></asp:Parameter>
                <asp:Parameter Name="ResultaatID"></asp:Parameter>
                <asp:Parameter Name="Punten"></asp:Parameter>
                <asp:Parameter Name="Hond1"></asp:Parameter>
                <asp:Parameter Name="Hond2"></asp:Parameter>
                <asp:Parameter Name="Hond3"></asp:Parameter>
                <asp:Parameter Name="Hond4"></asp:Parameter>
                <asp:Parameter Name="Hond5"></asp:Parameter>
                <asp:Parameter Name="Hond6"></asp:Parameter>
                <asp:Parameter Name="HeatID"></asp:Parameter>
            </UpdateParameters>
        </asp:SqlDataSource>

        <asp:SqlDataSource
            ID="SqlDataSource3"
            runat="server"
            ConnectionString="<%$ ConnectionStrings:FlyFormConnectionString %>"
            SelectCommand="
SELECT  [HeatID]
        ,[RaceID]
        ,[HeatNr]
        ,[BaanKleurID]
        ,[TeamID]
        ,[Tijd]
        ,[ResultaatID]
        ,isnull([Punten], 0) as Punten
        ,[Hond1]
        ,[Hond2]
        ,[Hond3]
        ,[Hond4]
        ,[Hond5]
        ,[Hond6]
FROM    [FlyFormHeat] 
WHERE   [RaceID] = @RaceID 
AND BaankleurID = 2 
ORDER BY [BaanKleurID], [HeatNr]" 
            UpdateCommand="
update [FlyForm].[dbo].[FlyFormHeat]
set             Tijd                    = @Tijd
                               ,ResultaatID= @ResultaatID
                               ,Punten                = @Punten
                               ,Hond1                 = @Hond1
                               ,Hond2                 = @Hond2
                               ,Hond3                 = @Hond3
                               ,Hond4                 = @Hond4
                               ,Hond5                 = @Hond5
                               ,Hond6                 = @Hond6
where  HeatID                 = @HeatID">
            <SelectParameters>
                <asp:ControlParameter ControlID="FormView1" DefaultValue="11736" Name="RaceID" PropertyName="SelectedValue" Type="Int32" />
            </SelectParameters>
            <UpdateParameters>
                <asp:Parameter Name="Tijd" DbType="Decimal"></asp:Parameter>
                <asp:Parameter Name="ResultaatID"></asp:Parameter>
                <asp:Parameter Name="Punten"></asp:Parameter>
                <asp:Parameter Name="Hond1"></asp:Parameter>
                <asp:Parameter Name="Hond2"></asp:Parameter>
                <asp:Parameter Name="Hond3"></asp:Parameter>
                <asp:Parameter Name="Hond4"></asp:Parameter>
                <asp:Parameter Name="Hond5"></asp:Parameter>
                <asp:Parameter Name="Hond6"></asp:Parameter>
                <asp:Parameter Name="HeatID"></asp:Parameter>
            </UpdateParameters>
        </asp:SqlDataSource>
        
        <asp:SqlDataSource 
            ID="SqlDataSource4" 
            runat="server" 
            ConnectionString="<%$ ConnectionStrings:FlyFormConnectionString %>" 
            SelectCommand="SELECT * FROM [FlyFormProgramma] WHERE ([RaceID] = @RaceID)">
            <SelectParameters>
                <asp:ControlParameter ControlID="FormView1" DefaultValue="11763" Name="RaceID" PropertyName="SelectedValue" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>

    </form>
</body>
</html>
