/*
 * Creado por SharpDevelop.
 * Usuario: eze
 * Fecha: 31/5/2025
 * Hora: 19:52
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */

using System;
using System.Collections;

namespace tpAlgortimos
{
	class Program
	{
		public static void Main(string[] args)
		{
			 //creo instancia de empresa
			Empresa empresa=new Empresa();
		
//			Obra ob=new Obra("nombre",4545,45,"remodelacion",12,JefedeObra jede,4545,Grupo Grupo);
			             
	  
			
			
			Console.WriteLine("-----------------------------------------------------------");
			Console.WriteLine("Ingrese la opcion deseada (para finalizar escriba `0´) :");
			Console.WriteLine("1- Contratar un nuevo obrero");
			Console.WriteLine("2- eliminar un obreros");
			Console.WriteLine("3- Submenú de impresión: listado de obreros, de obras en ejecución con más del 50% de avance, de obras finalizadas y de jefes");
			Console.WriteLine("4- Agregar una obra y asignarle un jefe. Se debe crear el jefe y asociarle el grupo de obreros que va a dirigir. Verificar que haya grupo libre; en caso contrario se debe levantar una excepción que informe lo sucedido.");
			Console.WriteLine("5- Modificar el estado de avance de una obra. Si el estado de avance llega al 100% la obra debe darse por finalizada, se elimina del listado de obras en ejecución y se guarda en el de obras finalizadas");
			Console.WriteLine("6- Dar de baja a un jefe ");
			Console.WriteLine("-----------------------------------------------------------");
			int opcion=int.Parse(Console.ReadLine());
			
			while (opcion!=0) {
						//agrego un obrero a la empresa y al grupo obrero
				switch (opcion) {
					case 1:
						AgregarObrero(empresa);
						break;
					case 2:
						Eliminar_Obrero(empresa);
						break;
					case 3:
						SubmenudeImpresion(empresa);
						break;
					default:
						Console.WriteLine("Opción no válida.");
						break;				}

				Console.WriteLine("-----------------------------------------------------");
		    Console.WriteLine("Ingrese la opcion deseada (para finalizar escriba `0´) :");
			Console.WriteLine("1- Contratar un nuevo obrero");
			Console.WriteLine("2- eliminar un obreros");
			Console.WriteLine("3- Submenú de impresión: listado de obreros, de obras en ejecución con más del 50% de avance, de obras finalizadas y de jefes");
			Console.WriteLine("4- Agregar una obra y asignarle un jefe. Se debe crear el jefe y asociarle el grupo de obreros que va a dirigir. Verificar que haya grupo libre; en caso contrario se debe levantar una excepción que informe lo sucedido.");
			Console.WriteLine("5- Modificar el estado de avance de una obra. Si el estado de avance llega al 100% la obra debe darse por finalizada, se elimina del listado de obras en ejecución y se guarda en el de obras finalizadas");
			Console.WriteLine("6- Dar de baja a un jefe ");
			Console.WriteLine("---------------------------------------------------------");
			opcion=int.Parse(Console.ReadLine());
			}
			
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
		
		
		
		
		
		
		public static void AgregarObrero(Empresa emp){
						Console.WriteLine("Ingrese los datos del Obrero: ");
						Console.WriteLine("Ingrese el nombre y apellido: ");
						string nombyape=Console.ReadLine();
						Console.WriteLine("Ingrese Dni");
						int dni=int.Parse(Console.ReadLine());
						Console.WriteLine("Ingrese Legajo:");
						int legajo=int.Parse(Console.ReadLine());
						Console.WriteLine("Ingrese sueldo:");
						double sueldo=double.Parse(Console.ReadLine());
						Console.WriteLine("Ingrese cargo: ");
						string cargo=Console.ReadLine();
						Obrero persona=new Obrero(nombyape,dni,legajo,sueldo,cargo);
						emp.ContratarObrero(persona);//se agrega obrero a la empresa
					
						Grupo asignogrupo;
						if(emp.GRUPOS.Count>0){
							asignogrupo=(Grupo)emp.GRUPOS[0]; //tomo la primer posicion de la lista y le asigno para agregarlo al obrero
							Console.WriteLine("se agrego al primer grupo ");
						}
						else{
							//si no encuentra grupo, crea y lo agrega a la empresa
							
							asignogrupo=new Grupo();
							emp.AgregarGrupo(asignogrupo); //Agrega un nuevo grupo a la lista general de grupos que maneja la empresa
							Console.WriteLine("se crea nuevo grupo y asigno al obrero");
						}
						asignogrupo.AgregarObrero(persona); //Agrega un obrero a la lista de obreros que forman parte de ese grupo
		}
		
		
		
		
		
		public static void Eliminar_Obrero(Empresa empresa){
			Console.WriteLine("ingrese el Dni del obrero que desea eliminar");
			int dni=int.Parse(Console.ReadLine());
			
			if (empresa.ExisteObrero(dni)) {
				Obrero obreroaeliminar=empresa.ObtenerObrero(dni);
				Grupo grupo=empresa.ObtenerObrerogrupo(dni);
				
				if(grupo !=null){
					grupo.EliminarObrero(obreroaeliminar);//elimina obreo del grupo(lista integrantes)
					
				}
				
				empresa.EliminarGrupo(grupo); //elimino obrero del grupo(lista grupo)
				
				empresa.EliminaObrero(obreroaeliminar);//elimina al obrero del lista de obrero(empresa lista obreros)
				Console.WriteLine("obrero eliminado correctamente");
				
			}
			else{
				Console.WriteLine("el obrero no fue encontrado");
			}
			
			
		
		
		}
		public static void SubmenudeImpresion(Empresa construccion){
			Console.WriteLine("--------------------------------");
//			listado de obreros, de obras en ejecución, de obras finalizadas y de 
//jefes, porcentaje de obras de remodelación sin finalizar. 
		Console.WriteLine("Submenú de Impresión:");
  		 Console.WriteLine("1- Listado de obreros");
    	 Console.WriteLine("2- Listado de obras en ejecución ");
    	 Console.WriteLine("3- Listado de obras finalizadas");
   		 Console.WriteLine("4- Listado de jefes");
   		 Console.WriteLine("5-porcentaje de obras de remodelación sin finalizar");
   		 Console.WriteLine("-------------------------------");
   		 int op=int.Parse(Console.ReadLine());
   		 switch (op) {
   		 	case 1:
   		 		construccion.ListarObreros();
   		 		break;
   		 	default:
   		 		Console.WriteLine("Opción no válida.");
   		 		break;
   		 }
		}
		
	}
	class Empresa{
		//Atributos
		private ArrayList Obras;
		private ArrayList Obreros;
		private ArrayList ObrasFinalizadas;
		private ArrayList Grupos;
		//Constructor
		public Empresa(){
			this.Obras=new ArrayList();
			this.Obreros=new ArrayList();
			this.ObrasFinalizadas=new ArrayList();
			this.Grupos=new ArrayList();
		}
		//metodos
		public Obrero ObtenerObrero(int dni){
			foreach(Obrero elem in this.Obreros){
				if(dni==elem.DNIOBRERO){
					return elem;
				}
			}
			return null;//vacio=null
		}
		public Grupo ObtenerObrerogrupo(int dni){
			foreach(Grupo elem in this.Grupos){//lista grupo
				foreach(Obrero emp in elem.INTEGRANTES){
				if(dni==emp.DNIOBRERO){
					return elem;
				}
				}}
			return null;//vacio
		}
	
			
			
		//se agrega un obrero a la lista de obreros
		public void ContratarObrero(Obrero obrero){
			this.Obreros.Add(obrero);
		}
		//eliminamos al obrero de la empresa(lista obreros)
		public void EliminaObrero(Obrero obr){
			this.Obreros.Remove(obr);
			
		}
		//Agrega un nuevo grupo a la lista general de grupos que maneja la empresa
		public void AgregarGrupo(Grupo g) {
  			this.Grupos.Add(g);
     }
		//eliminamos al obrero del grupo
		public void EliminarGrupo(Grupo g){
			this.Grupos.Remove(g);
		}
		public bool ExisteObrero(int dni){
			
//			foreach (Obra elem in this.Obras) {
//				if(dni ==elem.COSTO){
//					return elem;
//				}
//			}
			
			
			foreach (Obrero elem in this.Obreros) {
				if(dni==elem.DNIOBRERO){
					return true;
				}
			}
			return false;
			
		}
		public void ListarObreros(){
		 foreach (Obrero element in this.Obreros)
		 { 
        Console.WriteLine("Nombre y Apellido: " + element.NOMYAPE);
        Console.WriteLine("Dni: " + element.DNIOBRERO);
        Console.WriteLine("Cargo: " + element.CARGO);
        Console.WriteLine("sueldo: " + element.SUELDO);
        Console.WriteLine("legajo: " + element.LEGAJO);
        Console.WriteLine("------------------------");
		 	}
		
		
		
		}

		
		
		//Propiedades
		public ArrayList OBRAS{
			get{return this.Obras;}
		}
		public ArrayList OBREROS{
			get{return this.Obreros;}
		}
		public ArrayList OBRASFINALIZADAS{
			get{return this.ObrasFinalizadas;}
		}
		public ArrayList GRUPOS {
            get { return this.Grupos; }
        }
		
	}





//	De cada obra se conoce el nombre y dni del propietario, código interno (se lo asigna el
//sistema), tipo de obra (construcción, remodelación, ampliación, etc.), estado de avance (porcentaje), 
//el jefe de obra y el costo.
	class Obra{
		//Atributos
		private string NomObra;
		private int DniPropietario;
		private int CodigoInterno;
		private string TipoObra;
		private double EstadoAvance;
		private JefedeObra jefedeobra;
		private double costo;
		private Grupo grupoAsignado;
		//constructor
		public Obra(string no,int dp,int ci, string tp,double ea, JefedeObra j,double c,Grupo grup){
			this.NomObra=no;
			this.DniPropietario=dp;
			this.CodigoInterno=ci;
			this.TipoObra=tp;
			this.EstadoAvance=ea;
			this.jefedeobra=j;
			this.costo=c;
			this.grupoAsignado=grup;
		}
		
		
		//Propiedades
		public string NOMOBRA{
			get{return this.NomObra;}
			set{this.NomObra=value;}
		}
		public int DNIPROPIETARIO{
			get{return this.DniPropietario;}
			set{this.DniPropietario=value;}
		}
		public int CODIGOINTERNO{
			get{return this.CodigoInterno;}
			set{this.CodigoInterno=value;}
		}
		public string TIPOOBRA{
			get{return this.TipoObra;}
			set{this.TipoObra=value;}
		}
		public double ESTADOAVANCE{
			get{return this.EstadoAvance;}
			set{this.EstadoAvance=value;}
		}
		public JefedeObra JEFEDEOBRA{
			get{return this.jefedeobra;}
		    set{this.jefedeobra=value;}
		}
		public double COSTO{
			get{return this.costo;}
			set{this.costo=value;}
		}
		public Grupo GRUPOASIGNADO{
			get{return this.grupoAsignado;}
			set{this.grupoAsignado=value;}
		}
						
	}



//	 De cada obrero se almacena su nombre  y apellido, dni, nro legajo, sueldo
//y cargo (capataz, albañil, peón, plomero, electricista, etc.)
	
	class Obrero{
	//Atributos
	protected string NombYape;
	protected int DniObrero;
	protected int Legajo;
	protected double Sueldo;
	protected string Cargo;
	//constructor
	public Obrero(string nya,int d,int l,double s,string c){
		this.NombYape=nya;
		this.DniObrero=d;
		this.Legajo=l;
		this.Sueldo=s;
		this.Cargo=c;
		
	}
	//Propiedades
	public string NOMYAPE{
		get{return this.NombYape;}
		set{this.NombYape=value;}
	}
	public int DNIOBRERO{
		get{return this.DniObrero;}
		set{this.DniObrero=value;}
	}
	public int LEGAJO{
		get{return this.Legajo;}
		set{this.Legajo=value;}
	}
	public double SUELDO{
		get{return this.Sueldo;}
		set{this.Sueldo=value;}
	}
	public string CARGO{
		get{return this.Cargo;}
		set{this.Cargo=value;}
	}
		
		
	}
	//	El jefe de obra es un obrero responsable 
//de una obra por lo cual cobra una bonificación especial a parte de su sueldo  y dirige un grupo de 
//obreros que trabajan en dicha obra.
class JefedeObra:Obrero{
	//Atributo
	private double bonificacion;
	private Obra ObraAsignada;
	//Constructor
	public JefedeObra(string nya,int d,int l,double s,string c,double b,Obra oas):base(nya,d,l,s,c){
		this.bonificacion=b;
		this.ObraAsignada=oas;
	}
	//Propiedades
	public double BONIFICACION{
		get{return this.bonificacion;}
		set{this.bonificacion=value;}
	}
	public Obra OBRAASIGNADA{
		get{return this.ObraAsignada;}
		set{this.ObraAsignada=value;}
	}
	
}
class Grupo {
	//Atributos
	private ArrayList integrantes;
	//constructor
	public Grupo() {
		this.integrantes = new ArrayList();
	}
	    // metodo para agregar un obrero al grupo
    public void AgregarObrero(Obrero obrero) {
        this.integrantes.Add(obrero);
    }
	    public void EliminarObrero(Obrero ob){
	    	this.integrantes.Remove(ob);
	    }

	//propiedad
	public ArrayList INTEGRANTES {
		get { return this.integrantes; }
	}
}


}