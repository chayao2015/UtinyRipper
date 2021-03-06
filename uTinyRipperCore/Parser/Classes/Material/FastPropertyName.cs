﻿using SevenZip;
using uTinyRipper.AssetExporters;
using uTinyRipper.Exporter.YAML;

namespace uTinyRipper.Classes.Materials
{
	public struct FastPropertyName : IAssetReadable, IYAMLExportable
	{
		/// <summary>
		/// 2017.3 and greater
		/// </summary>
		private static bool IsPlainString(Version version)
		{
			return version.IsGreaterEqual(2017, 3);
		}

		public bool IsCRC28Match(uint crc)
		{
			return CRC.Verify28DigestUTF8(Value, crc);
		}

		public void Read(AssetReader reader)
		{
			Value = reader.ReadString();
		}

		public YAMLNode ExportYAML(IExportContainer container)
		{
#warning TODO: serialized version acording to read version (current 2017.3.0f3)
			//if(IsPlainString)
			{
				return new YAMLScalarNode(Value);
			}
			/*else
			{
				YAMLMappingNode node = new YAMLMappingNode();
				node.Add("name", Value);
				return node;
			}*/
		}

		public override int GetHashCode()
		{
			return Value.GetHashCode();
		}

		public override string ToString()
		{
			if(Value == null)
			{
				return base.ToString();
			}
			return Value;
		}

		public string Value { get; private set; }		
	}
}
