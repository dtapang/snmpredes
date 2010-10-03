////////////////////////////////////////////////////////////////////////////////
//
// SNMPDLL  (2006-02-08 09:30:00)
//
// Copyright (c) 2005 Olivier Griffet
//
// This library is based on the work of Marek Malowidzki and Malcolm Crowe
//
///////////////////////////////////////////////////////////////////////////////


using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Threading;
using Org.Snmp.Snmp_pp;
using RFC1157;

namespace SNMPDll
{
	/// <summary>
	/// This class allow you to create a MIB
	/// </summary>
	public class Mib
	{
		#region init variable + decl variable + constructor
		private Mgmt myMib;
		private Hashtable htOIDName; //key=OID value = fullName; key=name value = OID; key = fullName value = OID

		public Mib()
		{
			myMib = new Mgmt();
			htOIDName = new Hashtable(); 
		}
		#endregion

		#region public method


		#region get Or exist OID - name - fullName
		/// <summary>
		/// Try to see if an OID exists into the loaded mib
		/// </summary>
		/// <param name="OID">oid string</param>
		/// <returns>true if exist else false</returns>
		public bool existOID(string OID)
		{
			if (this.getFullName(OID) != "")return true;
			else return false;
		}


		/// <summary>
		/// Try to see if a fullName exists into the loaded mib
		/// </summary>
		/// <param name="fullName">fullName of an oid</param>
		/// <returns>true if exist else false</returns>
		public bool existFullName(string fullName)
		{
			if (this.getOID(fullName) != "")return true;
			else return false;
		}



		/// <summary>
		/// Try to find the simple name of the OID (last part of the name)
		/// </summary>
		/// <param name="OID">OID</param>
		/// <returns>the last part of the full name or emptyString if the OID does not exist</returns>
		public string getSimpleName(string OID)
		{
			if (this.htOIDName.Contains(OID))
			{
				string[] s = ((string)htOIDName[OID]).Split('.');
				return s[s.Length-1];
			}
			else
			{
				string[] s = this.getFullName(OID).Split('.');
				return s[s.Length-1];
			}
		}



		/// <summary>
		/// Look after OID from a simple name. 
		/// </summary>
		/// <param name="name">simple name (not the fullName path</param>
		/// <returns>Return the OID or return empty string if the name does not exist</returns>
		public string getOIDFromSimpleName(string name)
		{
			if (!this.htOIDName.Contains(name)) return (string)this.htOIDName[name];
			
			//Parcourir tout et si trouvé, balancer information
			Console.WriteLine("Walk through the MIB to get the information");
			walk();

			if (!this.htOIDName.Contains(name)) return (string)this.htOIDName[name];
			else return "";
		}



		/// <summary>
		/// Return the OID of the fullname given path
		/// </summary>
		/// <param name="fullName"></param>
		/// <returns></returns>
		public string getOID(string fullName)
		{
			try
			{
				if (!this.htOIDName.Contains(fullName)) return (string)this.htOIDName[fullName];
				else this.htOIDName.Add(fullName,this.myMib.giveOID(fullName));
				return (string)this.htOIDName[fullName];
			}
			catch //Does not exist OID with the full name given
			{
				return "";
			}
		}


		/// <summary>
		/// Look after the full name from the OID
		/// </summary>
		/// <param name="OID"></param>
		/// <returns></returns>
		public string getFullName(string OID)
		{
			try
			{
				if (this.htOIDName.Contains(OID)) return (string)this.htOIDName[OID];
				else this.htOIDName.Add(OID,this.myMib.getFullNameFromOID(OID));
				return (string)this.htOIDName[OID];
			}
			catch //Does not exist OID with the full name given
			{
				return "";
			}
		}
		#endregion


		/// <summary>
		/// Look if a SNMPObject has a description, if not return emptyString
		/// </summary>
		/// <param name="mySNMPObject"></param>
		/// <returns></returns>
		public string getDescription(SNMPObject mySNMPObject)
		{
			return mySNMPObject.getDescription();
		}


		/// <summary>
		/// Method used on mib.dll
		/// </summary>
		/// <param name="OID"></param>
		/// <returns></returns>
		public string getDescription(string OID)
		{
			return this.myMib.getDescription(OID);
		}

		#region load mib, add OID
		/// <summary>
		/// try to add an OID with his name to the MIB. ! the OID parent must exsit
		/// </summary>
		/// <param name="OID">OID to add</param>
		/// <param name="name">name of the OID</param>
		/// <exception cref="Exception">return an exception if the OID parent does not already exist into the MIB or if the OID already exist with an different name</exception>
		public void addOIDName(string OID, string name)
		{
			string[] s = OID.Split('.');
			string OIDParent = "";
			for (int j=0;j<s.Length-1;j++)
			{
				OIDParent += s[j];
			}
			
			//If the OID parent does not exist throw an error
			if (!this.existOID(OIDParent)) throw new Exception("Error the OID parent : " + OIDParent + " does not exist into the MIB");
			//If the added already exist with a different name throw an error
			if (this.existOID(OID))
			{
				if (this.getSimpleName(OID) != name) throw new Exception("Error : the OID already exist with an different name");
				else return;
			}

			//Sinon ajouter
			this.htOIDName.Add(OID, this.getFullName(OIDParent) + "." + name);
		}



		/// <summary>
		/// Load a mib file
		/// </summary>
		/// <param name="fileName"></param>
		public void loadMib(string fileName)
		{
			myMib.loadFile(fileName);
		}



		/// <summary>
		/// Load all mib file of a directory
		/// </summary>
		/// <param name="directoryName"></param>
		public void loadDirectoryMib(string directoryName)
		{
			DirectoryInfo dir = new DirectoryInfo(directoryName);
			FileInfo[] list = dir.GetFiles("*.mib");
			foreach (FileInfo f in list) 
			{
				this.loadMib(f.FullName);
				Console.WriteLine("Load " + f.FullName);
			}
		}

		#endregion

		/// <summary>
		/// Display to the Console the result of the mib
		/// </summary>
		public void walk()
		{
			//Private part
			Console.WriteLine("Walk thru the private part of the MIB");
			giveAllKids("private");

			//Mgmt part
			Console.WriteLine("Walk through the Mgmt part of the MIB");
			giveAllKids("mgmt");
		}



		/// <summary>
		/// Write the result into a file
		/// </summary>
		/// <param name="fileName"></param>
		public void walk(string fileName)
		{
			StreamWriter sw = new StreamWriter(fileName);
			//Private part
			Console.WriteLine("Private part");
			giveAllKids("private",sw);

			//Mgmt part
			Console.WriteLine("Mgmt part");
			giveAllKids("mgmt",sw);
			
		}




		#endregion

		#region private part
		#region private method for the walk method
		/// <summary>
		/// Procédure récursive
		/// </summary>
		/// <param name="nameParent"></param>
		private void giveAllKids(string nameParent, StreamWriter sw)
		{
			string[] result = giveKids(nameParent);
						
			for (int j=0;j<result.Length;j++)
			{
				Def tempMo = myMib.getDef(nameParent + "." + result[j]);
				string myOID = myMib.giveOID(nameParent + "." + result[j]);
				if (tempMo!=null && tempMo.help!=null)
				{

					Console.WriteLine(myOID + ";" +  result[j] + ";" + tempMo.help.ToString());
					sw.WriteLine(myOID+ ";" +  result[j] + ";" + tempMo.help.ToString());
					
				}
				else
				{
					Console.WriteLine(myOID + ";" +  result[j]);
					sw.WriteLine(myOID + ";" +  result[j]);
				}
				if (!this.htOIDName.Contains(result[j])) this.htOIDName.Add(result[j],myOID);
				giveAllKids(nameParent + "." + result[j],sw);
			}


			
		}

		/// <summary>
		/// RECURSIVE PROCEDURE
		/// </summary>
		/// <param name="nameParent"></param>
		private void giveAllKids(string nameParent)
		{
			string[] result = giveKids(nameParent);			
			
			for (int j=0;j<result.Length;j++)
			{
				Def tempMo = myMib.getDef(nameParent + "." + result[j]);
				string myOID = myMib.giveOID(nameParent + "." + result[j]);
				if (tempMo!=null && tempMo.help!=null)
				{
					Console.WriteLine(myOID + " : " +  result[j]);
					Console.WriteLine("Description : " + tempMo.help.ToString());		
				}
				else
				{
					Console.WriteLine(myOID + " : " +  result[j]);

				}
				if (!this.htOIDName.Contains(result[j])) this.htOIDName.Add(result[j],myOID);
				giveAllKids(nameParent + "." + result[j]);
			}
		}

		private string[] giveKids (string nameParent)
		{
			string[] oid = nameParent.Split('.');
			int j=0;
			string name = "";
			Def mo = myMib.def;
			for (j=0;j<oid.Length;j++) 
			{
				Def mn = mo[oid[j]];
				if (mn==null)
					break;
				mo = mn;
				if (j!=0)
					name += ".";
				name += oid[j];
			}
			string[] kids = mo.Kids();
			return kids;
		}
		#endregion
		#endregion

	}



	#region SNMPObject
	public class SNMPObject
	{

		string OID;
		string description = "";
		string myValue = null;
		string fullName = null;
		string myType = null;

		/// <summary>
		/// Constructeur où le paramètre est toujours un OID
		/// </summary>
		/// <param name="OID"></param>
		public SNMPObject(string OID)
		{
			this.OID = OID;
			//Mettre la description
		}

		/// <summary>
		/// Constructeur où  l'ID est soit un OID soit un full name qui décrit l'ID
		/// </summary>
		/// <param name="ID"></param>
		/// <param name="_mib"></param>
		public SNMPObject(string ID, Mib _mib)
		{
			//Repérer si l'ID donné est un OID ou un fullName
			if (char.IsDigit(ID,0))
			{
				this.OID = ID;
			}
			else
			{
				this.OID = _mib.getOID(ID);
			}

			//Mettre la description
			this.description = _mib.getDescription(OID);
			this.fullName = _mib.getFullName(OID);
			string aaa;

		}

		/// <summary>
		/// Get the value of the SNMPObject
		/// </summary>
		/// <param name="myAgent">the SNMPAgent where you wanna take the value</param>
		/// <returns>
		/// (string)ht["value"] = value of the snmp request of the SNMPObject
		///	(string)ht["type"] = type of the snmp request of the SNMPObject
		///	</returns>
		public Hashtable getValue(SNMPAgent myAgent)
		{
			Hashtable ht = myAgent.getValue(this);
			myValue = (string)ht["value"];
			myType = (string)ht["type"];
			return ht;
		}


		/// <summary>
		/// Get the value of the SNMPObject
		/// </summary>
		/// <param name="myAgent">the SNMPAgent where you wanna take the value</param>
		/// <returns>the value cast to a string</returns>
		public string getSimpleValue(SNMPAgent myAgent)
		{
			if (myValue == null)
			{
				Hashtable ht = myAgent.getValue(this);
				myValue = (string)ht["value"];
				myType = (string)ht["type"];
			}
			return myValue;
		}

		public string getTypeString(SNMPAgent myAgent)
		{
			if (myType == null)
			{
				Hashtable ht = myAgent.getValue(this);
				myValue = (string)ht["value"];
				myType = (string)ht["type"];
			}
			return myType;
		}

		public string getTypeString()
		{
			if (myType == null)
			{
				throw new Exception("You must first defined a SNMPAgent");
			}
			else return myType;
		}


		public SNMPOIDType getType(SNMPAgent myAgent)
		{
			if (myType == null)
			{
				this.getTypeString(myAgent);
			}
			return this.getType();

		}

		public SNMPOIDType getType()
		{
			if (myType == null)
			{
				throw new Exception("You must first defined a SNMPAgent");
			}
			string aaa = SNMPOIDType.OctetString.ToString();
			if (myType == SNMPOIDType.Counter32.ToString()) return SNMPOIDType.Counter32;
			else if (myType == SNMPOIDType.Gauge32.ToString()) return SNMPOIDType.Gauge32;
			else if (myType == SNMPOIDType.Int.ToString()) return SNMPOIDType.Int;
			else if (myType == SNMPOIDType.IpAddress.ToString()) return SNMPOIDType.IpAddress;
			else if (myType == SNMPOIDType.OctetString.ToString()) return SNMPOIDType.OctetString;
			else if (myType == SNMPOIDType.Oid.ToString()) return SNMPOIDType.Oid;
			else if (myType == SNMPOIDType.TimeTicks.ToString()) return SNMPOIDType.TimeTicks;
			else throw new Exception("Type not found...");
				
		}


		public string getFullName()
		{
			if (fullName == null)
			{
				throw new Exception("You must first defined the MIB");
			}
			return fullName;
		}


		public string getFullName(Mib _mib)
		{
			if (fullName == "")
			{
				fullName = _mib.getFullName(this.OID);
			}
			return fullName;
		}


		public string getOID()
		{
			return OID;
		}

		public string getDescription()
		{
			return description;
		}


	}

	#endregion



	#region SNMPAgent
	/// <summary>
	/// The SNMPagent is the server/computer you ask a SNMP request
	/// </summary>
	public class SNMPAgent
	{

		string IPAddress = "";
		string communityRead = "";
		string communityWrite = "";

		/// <summary>
		/// Construtor. Create a SNMP agent
		/// </summary>
		/// <param name="IPAddress">The IPAddress of the agent</param>
		/// <param name="communityRead">The read community string of the agent</param>
		/// <param name="communityWrite">The write community string of the agent</param>
		public SNMPAgent(string IPAddress, string communityRead, string communityWrite)
		{
			this.IPAddress = IPAddress;
			this.communityRead = communityRead;
			this.communityWrite = communityWrite;
		}

		/// <summary>
		/// Construtor. Create a SNMP agent
		/// </summary>
		/// <param name="IPAddress">The IPAddress of the agent</param>
		public SNMPAgent(string IPAddress)
		{
			this.IPAddress = IPAddress;
			this.communityRead = "public";
			this.communityWrite = "public";
		}


		/// <summary>
		/// Walk thru the tree from the SNMPObject given in argument
		/// </summary>
		/// <param name="mySNMPOID"></param>
		public void walk(SNMPObject mySNMPOID)
		{
			string [] args = new string[7];
			args[0] = "walk";
			args[1] = this.getIPAddress();
			args[2] = "-o";
			//args[3] = this.OID + ".0";
			args[3] = mySNMPOID.getOID();
			args[4] = "-Dl0"; //don't make debug
			args[5] = "-c" + this.getCommunityRead(); //community read
			args[6] = "-C" + this.getCommunityWrite(); //community write


			//launch request
			Manager.makeOrder(args);
		}


		/// <summary>
		/// Get the value of the SNMPObject
		/// </summary>
		/// <param name="mySNMPObject">the SNMPObject we want the value</param>
		/// <returns>
		/// (string)ht["value"] = value of the snmp request of the SNMPObject
		///	(string)ht["type"] = type of the snmp request of the SNMPObject
		///	</returns>
		public Hashtable getValue(SNMPObject mySNMPObject)
		{

			string [] args = new string[7];
			args[0] = "get";
			args[1] = this.getIPAddress();
			args[2] = "-o";
			//args[3] = this.OID + ".0";
			args[3] = mySNMPObject.getOID();
			args[4] = "-Dl0"; //don't make debug
			args[5] = "-c" + this.getCommunityRead(); //community read
			args[6] = "-C" + this.getCommunityWrite(); //community write

			//lancer la requête
			Hashtable htResult = Manager.makeOrder(args);
			htResult.Add("value",(string)((Hashtable)htResult[1])["value"]);
			htResult.Add("type",(string)((Hashtable)htResult[1])["type"]);
			return htResult;
		}



		/// <summary>
		/// Get the value of the SNMPObjects given in argument
		/// </summary>
		/// <param name="SNMPObjects">the SNMPObjects you wanna take the value</param>
		/// <returns>
		/// htResult[1] = hashtable containing the value/type of the snmp request for the SNMPObject[0]
		///	htResult[2] = hashtable containing the value/type of the snmp request for the SNMPObject[1]
		///	(string)((Hashtable)ht[1])["value"] = value of the snmp request for the SNMPObject[0]
		///	(string)((Hashtable)ht[1])["type"] = type of the snmp request for the SNMPObject[0]
		///	</returns>
		public Hashtable getValues(SNMPObject[] SNMPObjects)
		{

			int nbrArgs = 5 + 2 * SNMPObjects.Length;
			string [] args = new string[nbrArgs];
			args[0] = "get";
			args[1] = this.getIPAddress();
			args[2] = "-Dl0"; //don't make debug
			args[3] = "-c" + this.getCommunityRead(); //community read
			args[4] = "-C" + this.getCommunityWrite(); //community write
			int i = 5;
			foreach(SNMPObject mySNMPObject in SNMPObjects)
			{
				args[i] = "-o";
				args[i+1] = mySNMPObject.getOID();
				i = i + 2;
			}

			//lancer la requête
			Hashtable htResult = Manager.makeOrder(args);
			return htResult;
		}


		/// <summary>
		/// Get the value of the OID deduced by the fullName of the OID and the mib given in argument
		/// </summary>
		/// <param name="fullNameArray">full name of the oid's</param>
		/// <param name="myMib">a mib</param>
		/// <returns></returns>
		public Hashtable getValues(string[] fullNameArray, Mib myMib)
		{
			SNMPObject[] mySNMPObjects = new SNMPObject[fullNameArray.Length];
			int i = 0;
			foreach(string fullName in fullNameArray)
			{
				mySNMPObjects[i] = new SNMPObject(myMib.getOID(fullName));
				i++;
			}
			return this.getValues(mySNMPObjects);			
		}


		/// <summary>
		/// Get the value of the OID deduced by the full name of the OID and and the mib given in argument
		/// </summary>
		/// <param name="fullName"></param>
		/// <param name="myMib"></param>
		/// <returns></returns>
		public Hashtable getValue(string fullName, Mib myMib)
		{
			return this.getValue(new SNMPObject(myMib.getOID(fullName)));
		}


		public void setValue(SNMPObject mySNMPObject, SNMPOIDType myType, string myValue)
		{
			string [] args = new string[9];
			args[0] = "set";
			args[1] = this.IPAddress;
			args[2] = "-o";
			args[3] = mySNMPObject.getOID();
			args[4] = "-Dl0";
			args[5] = "-c" + this.communityRead;
			args[6] = "-C" + this.communityWrite;
			args[7] = "-V" + myValue;
			args[8] = "-T" + myType.ToString();
			Manager.makeOrder(args);
		}

		public void setValue(SNMPObject mySNMPObject, SNMPOIDType myType, int myValue)
		{
			this.setValue(mySNMPObject, myType, myValue.ToString());
		}

		public void setValue(SNMPObject mySNMPObject, SNMPOIDType myType, TimeSpan myValue)
		{
			this.setValue(mySNMPObject, myType, myValue.Days.ToString() + " days " + myValue.Hours + ":" + myValue.Minutes + ":" + myValue.Seconds);
		}



		public string getIPAddress() {return IPAddress;}

		public string getCommunityRead() {return communityRead;}

		public string getCommunityWrite() {return communityWrite;}
	}
	#endregion


	#region SNMPOIDType
	public enum SNMPOIDType
	{
		OctetString,
		Int,
		Counter32,
		TimeTicks,
		Gauge32,
		IpAddress,
		Oid
	}
	#endregion
}
