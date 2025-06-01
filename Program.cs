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
			Console.WriteLine("Hello World!");
			
			// TODO: Implement Functionality Here
			Console.WriteLine("hola");
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
	class Empresa{
		//Atributos
		private ArrayList Obras;
		private ArrayList Obreros;
		private ArrayList ObrasFinalizadas;
		//Constructor
		public Empresa(){
			this.Obras=new ArrayList();
			this.Obreros=new ArrayList();
			this.ObrasFinalizadas=new ArrayList();
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
		//constructor
		public Obra(string no,int dp,int ci, string tp,double ea, JefedeObra j,double c){
			this.NomObra=no;
			this.DniPropietario=dp;
			this.CodigoInterno=ci;
			this.TipoObra=tp;
			this.EstadoAvance=ea;
			this.jefedeobra=j;
			this.costo=c;
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
	//Constructor
	public JefedeObra(string nya,int d,int l,double s,string c,double b):base(nya,d,l,s,c){
		this.bonificacion=b;
	}
	//Propiedades
	public double BONIFICACION{
		get{return this.bonificacion;}
		set{this.bonificacion=value;}
	}
	
}

}