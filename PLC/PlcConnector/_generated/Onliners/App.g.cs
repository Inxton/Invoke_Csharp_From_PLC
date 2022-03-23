using System;
using Vortex.Connector;
using Vortex.Connector.Peripheries;
using Vortex.Connector.Attributes;
using Vortex.Connector.ValueTypes;
using Vortex.Connector.Identity;

namespace Plc
{
#pragma warning disable SA1402, CS1591, CS0108, CS0067
	[Vortex.Connector.Attributes.TypeMetaDescriptorAttribute("{attribute addProperty Name \"\" }", "App", "Plc", TypeComplexityEnum.Complex)]
	public partial class App : TcoCore.TcoContext, Vortex.Connector.IVortexObject, IApp, IShadowApp, Vortex.Connector.IVortexOnlineObject, Vortex.Connector.IVortexShadowObject
	{
		Vortex.Connector.ValueTypes.OnlinerReal _Increment;
		public Vortex.Connector.ValueTypes.OnlinerReal Increment
		{
			get
			{
				return _Increment;
			}
		}

		Vortex.Connector.ValueTypes.Online.IOnlineReal IApp.Increment
		{
			get
			{
				return Increment;
			}
		}

		Vortex.Connector.ValueTypes.Shadows.IShadowReal IShadowApp.Increment
		{
			get
			{
				return Increment;
			}
		}

		TcoCore.TcoRemoteTask _Invoke_C_Sharp;
		public TcoCore.TcoRemoteTask Invoke_C_Sharp
		{
			get
			{
				return _Invoke_C_Sharp;
			}
		}

		TcoCore.ITcoRemoteTask IApp.Invoke_C_Sharp
		{
			get
			{
				return Invoke_C_Sharp;
			}
		}

		TcoCore.IShadowTcoRemoteTask IShadowApp.Invoke_C_Sharp
		{
			get
			{
				return Invoke_C_Sharp;
			}
		}

		public new void LazyOnlineToShadow()
		{
			base.LazyOnlineToShadow();
			Increment.Shadow = Increment.LastValue;
			Invoke_C_Sharp.LazyOnlineToShadow();
		}

		public new void LazyShadowToOnline()
		{
			base.LazyShadowToOnline();
			Increment.Cyclic = Increment.Shadow;
			Invoke_C_Sharp.LazyShadowToOnline();
		}

		public new PlainApp CreatePlainerType()
		{
			var cloned = new PlainApp();
			base.CreatePlainerType(cloned);
			cloned.Invoke_C_Sharp = Invoke_C_Sharp.CreatePlainerType();
			return cloned;
		}

		protected PlainApp CreatePlainerType(PlainApp cloned)
		{
			base.CreatePlainerType(cloned);
			cloned.Invoke_C_Sharp = Invoke_C_Sharp.CreatePlainerType();
			return cloned;
		}

		partial void PexPreConstructor(Vortex.Connector.IVortexObject parent, string readableTail, string symbolTail);
		partial void PexPreConstructorParameterless();
		partial void PexConstructor(Vortex.Connector.IVortexObject parent, string readableTail, string symbolTail);
		partial void PexConstructorParameterless();
		public void FlushPlainToOnline(Plc.PlainApp source)
		{
			source.CopyPlainToCyclic(this);
			this.Write();
		}

		public void CopyPlainToShadow(Plc.PlainApp source)
		{
			source.CopyPlainToShadow(this);
		}

		public new void FlushShadowToOnline()
		{
			this.LazyShadowToOnline();
			this.Write();
		}

		public new void FlushOnlineToShadow()
		{
			this.Read();
			this.LazyOnlineToShadow();
		}

		public void FlushOnlineToPlain(Plc.PlainApp source)
		{
			this.Read();
			source.CopyCyclicToPlain(this);
		}

		public App(Vortex.Connector.IVortexObject parent, string readableTail, string symbolTail): base (parent, readableTail, symbolTail)
		{
			this.@SymbolTail = symbolTail;
			this.@Connector = parent.GetConnector();
			this.@Parent = parent;
			_humanReadable = Vortex.Connector.IConnector.CreateSymbol(parent.HumanReadable, readableTail);
			PexPreConstructor(parent, readableTail, symbolTail);
			Symbol = Vortex.Connector.IConnector.CreateSymbol(parent.Symbol, symbolTail);
			_Increment = @Connector.Online.Adapter.CreateREAL(this, "", "Increment");
			_Invoke_C_Sharp = new TcoCore.TcoRemoteTask(this, "", "Invoke_C_Sharp");
			PexConstructor(parent, readableTail, symbolTail);
		}

		public App(): base ()
		{
			PexPreConstructorParameterless();
			_Increment = Vortex.Connector.IConnectorFactory.CreateREAL();
			_Invoke_C_Sharp = new TcoCore.TcoRemoteTask();
			PexConstructorParameterless();
		}
	}

	
            /// <summary>
            /// This is POCO object for its respective onliner class. For documentation of this type see the onliner class.
            /// </summary>
            /// <exclude />
	public partial class PlainApp
	{
		public void CopyPlainToCyclic(Plc.App target)
		{
			base.CopyPlainToCyclic(target);
			target.Increment.Cyclic = Increment;
			Invoke_C_Sharp.CopyPlainToCyclic(target.Invoke_C_Sharp);
		}

		public void CopyPlainToCyclic(Plc.IApp target)
		{
			this.CopyPlainToCyclic((Plc.App)target);
		}

		public void CopyPlainToShadow(Plc.App target)
		{
			base.CopyPlainToShadow(target);
			target.Increment.Shadow = Increment;
			Invoke_C_Sharp.CopyPlainToShadow(target.Invoke_C_Sharp);
		}

		public void CopyPlainToShadow(Plc.IShadowApp target)
		{
			this.CopyPlainToShadow((Plc.App)target);
		}

		public void CopyCyclicToPlain(Plc.App source)
		{
			base.CopyCyclicToPlain(source);
			Increment = source.Increment.LastValue;
			Invoke_C_Sharp.CopyCyclicToPlain(source.Invoke_C_Sharp);
		}

		public void CopyCyclicToPlain(Plc.IApp source)
		{
			this.CopyCyclicToPlain((Plc.App)source);
		}

		public void CopyShadowToPlain(Plc.App source)
		{
			base.CopyShadowToPlain(source);
			Increment = source.Increment.Shadow;
			Invoke_C_Sharp.CopyShadowToPlain(source.Invoke_C_Sharp);
		}

		public void CopyShadowToPlain(Plc.IShadowApp source)
		{
			this.CopyShadowToPlain((Plc.App)source);
		}
	}
}