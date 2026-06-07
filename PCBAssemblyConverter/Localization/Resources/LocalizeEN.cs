namespace PCBAssemblyConverter.Localization.Resources
{
    public class LocalizeEN : LocalizeBase
    {
        public override string Home_About_Header => "About";

        public override string Home_About_Sentence_1 => "Converts BOM and POS files exported from PCB design software into submission files for PCB assembly service.";

        public override string Home_About_Sentence_2 => "The converted BOM/POS files and the conversion rules can be downloaded together as a ZIP archive.";

        public override string Home_Support_Header => "Supported Software & Assembly Service";

        public override string Home_Support_Eda => "Design Software";

        public override string Home_Support_Manufacturer => "Assembly Service";

        public override string Home_HowToUse_Header => "How to Use";

        public override string Home_HowToUse_Step_1 => "Select the design software and assembly service";

        public override string Home_HowToUse_Step_2 => "Load the BOM and POS files";

        public override string Home_HowToUse_Step_3 => "Configure conversion rules";

        public override string Home_HowToUse_Step_3_SubSentence_1 => "Edit manually";

        public override string Home_HowToUse_Step_3_SubSentence_2 => "Load an existing JSON file";

        public override string Home_HowToUse_Step_4 => "Convert and download";

        public override string Home_StartButton_Text => "Get Started";

        public override string Converter_InOut_Selector_Header => "Conversion Settings";

        public override string Converter_BomData_Header => "BOM preview";

        public override string Converter_PosData_Header => "POS preview";

        public override string Converter_BomPos_Input_Header => "Input Files";

        public override string Converter_BomPos_Input_Bom_DDButton_Text => "BOM";

        public override string Converter_BomPos_Input_Bom_DDButton_Description => "Drop files here or click to select";

        public override string Converter_BomPos_Input_Bom_DDButton_SubDescription => "Supported formats";

        public override string Converter_BomPos_Input_Pos_DDButton_Text => "POS";

        public override string Converter_BomPos_Input_Pos_DDButton_Description => "Drop files here or click to select";

        public override string Converter_BomPos_Input_Pos_DDButton_SubDescription => "Supported formats";

        public override string Converter_ConversionRule_Editor_Header => "Conversion Rules";

        public override string Converter_ConversionRule_Editor_ConversionRule_DDButton_Text => "Conversion Rules";

        public override string Converter_ConversionRule_Editor_ConversionRule_DDButton_Description => "Drop files here or click to select";

        public override string Converter_ConversionRule_Editor_ConversionRule_DDButton_SubDescription => "Supported formats";

        public override string Converter_Result_Header => "Output";

        public override string Converter_ConvertButton_Text => "Convert";

        public override string Converter_DownloadButton_Text => "Download";

        public override string Converter_Error_Message_is_not_supported => "is not supported.";

        public override string Converter_Error_Message_file_load_failed => "Failed to load the file.";

        public override string Converter_Error_Message_should_select_json => "Please select a JSON file.";

        public override string Converter_Error_Message_ConversionRule_load_failed => "Failed to load the conversion rules.";

        public override string Converter_Error_Message_Bom_convert_failed => "Failed to convert the BOM file.";

        public override string Converter_Error_Message_Pos_convert_failed => "Failed to convert the POS file.";

        public override string Converter_Error_Message_download_file_create_failed => "Failed to create the download file.";

        public override string Converter_Notice_Message_Bom_loaded => "BOM file loaded.";

        public override string Converter_Notice_Message_Pos_loaded => "POS file loaded.";

        public override string Converter_Notice_Message_ConversionRule_loaded => "Conversion rules loaded.";

        public override string Converter_Notice_Message_convert_finished => "Conversion completed.";

        public override string FileName_Display_Text => "File name";

        public override string RecordCount_Display_Text => "Record count";

        public override string RecordCount_Format => "records";

        public override string Message_no_data_to_display => "No data to display.";

        public override string ConversionRuleGrid_EditButton_Text => "Edit";

        public override string ConversionRuleGrid_SaveButton_Text => "Save";

        public override string ConversionRuleGrid_CancelButton_Text => "Cancel";

        public override string ConversionRule_Description_Header => "About Conversion Rules";

        public override string ConversionRule_SpecTable_Header_Name => "Property";

        public override string ConversionRule_SpecTable_Header_DataType => "Type";

        public override string ConversionRule_SpecTable_Header_Enum => "Options";

        public override string ConversionRule_SpecTable_Header_Description => "Description";

        public override string ConversionRule_SpecTable_Name_Property_DataType => "String";

        public override string ConversionRule_SpecTable_Name_Property_Enum => "-";

        public override string ConversionRule_SpecTable_Name_Property_Description_Sentence_1 => "Name of the conversion rule.";

        public override string ConversionRule_SpecTable_Key_Property_DataType => "String";

        public override string ConversionRule_SpecTable_Key_Property_Enum => "-";

        public override string ConversionRule_SpecTable_Key_Property_Description_Sentence_1 => "Key used to identify footprints to which this rule will be applied.";

        public override string ConversionRule_SpecTable_MatchingStrategy_Property_DataType => "Enum";

        public override string ConversionRule_SpecTable_MatchingStrategy_Property_Enum => "";

        public override string ConversionRule_SpecTable_OffsetX_Property_DataType => "Double";

        public override string ConversionRule_SpecTable_OffsetX_Property_Enum => "-";

        public override string ConversionRule_SpecTable_OffsetX_Property_Description_Sentence_1 => "X-axis offset between the footprint origin and the actual component placement position.";

        public override string ConversionRule_SpecTable_OffsetY_Property_DataType => "Double";

        public override string ConversionRule_SpecTable_OffsetY_Property_Enum => "-";

        public override string ConversionRule_SpecTable_OffsetY_Property_Description_Sentence_1 => "Y-axis offset between the footprint origin and the actual component placement position.";

        public override string ConversionRule_SpecTable_ChangeSide_Property_DataType => "Enum";

        public override string ConversionRule_SpecTable_ChangeSide_Property_Enum => "";

        public override string ConversionRule_SpecTable_RatationAdjustment_Property_DataType => "Enum";

        public override string ConversionRule_SpecTable_RatationAdjustment_Property_Enum => "";

        public override string ConversionRule_SpecTable_RatationAdjustment_Property_Description_Sentence_1 => "Compensates for the rotational difference between the footprint and the actual component orientation.";

        public override string ConversionRule_SpecTable_ManufacturerPartNumber_Property_DataType => "String";

        public override string ConversionRule_SpecTable_ManufacturerPartNumber_Property_Enum => "-";

        public override string ConversionRule_SpecTable_ManufacturerPartNumber_Property_Description_Sentence_1 => "Part number used when ordering or assembling the component.";

        public override string ConversionRule_SpecTable_ManufacturerPartNotes_Property_DataType => "String";

        public override string ConversionRule_SpecTable_ManufacturerPartNotes_Property_Enum => "-";

        public override string ConversionRule_SpecTable_ManufacturerPartNotes_Property_Description_Sentence_1 => "Reference information for the component, such as a datasheet or supplier link.";

        public override string ConversionRule_SpecTable_ManufacturerPartNotes_Property_Description_Sentence_2 => "Can also be used for notes.";

        public override string ConversionRule_SpecTable_RuleAction_Property_DataType => "Enum";

        public override string ConversionRule_SpecTable_RuleAction_Property_Enum => "";

        public override string ConversionRule_Name_Property_Display_Text => "Rule Name";

        public override string ConversionRule_Key_Property_Display_Text => "Key";

        public override string ConversionRule_MatchingStrategy_Property_Display_Text => "Match Type";

        public override string ConversionRule_OffsetX_Property_Display_Text => "Offset X";

        public override string ConversionRule_OffsetY_Property_Display_Text => "Offset Y";

        public override string ConversionRule_ChangeSide_Property_Display_Text => "Placement Side";

        public override string ConversionRule_RotationAdjustment_Property_Display_Text => "Rotation Offset";

        public override string ConversionRule_ManufacturerPartNumber_Property_Display_Text => "Part Number";

        public override string ConversionRule_ManufacturerPartNotes_Property_Display_Text => "Part Notes";

        public override string ConversionRule_RuleAction_Property_Display_Text => "Action";

        public override string MatchingStrategy_Exact_Display_Text => "Exact Match";

        public override string MatchingStrategy_Contains_Display_Text => "Contains";

        public override string MatchingStrategy_Regex_Display_Text => "Regular Expression";

        public override string MatchingStrategy_Exact_Description => "Apply this rule only to footprints that exactly match the key.";

        public override string MatchingStrategy_Contains_Description => "Apply this rule to footprints that contain the key.";

        public override string MatchingStrategy_Regex_Description => "Apply this rule to footprints that match the regular expression specified in the key.";

        public override string ChangeSide_None_Display_Text => "None";

        public override string ChangeSide_Top_Display_Text => "Top";

        public override string ChangeSide_Bottom_Display_Text => "Bottom";

        public override string ChangeSide_Reverse_Display_Text => "Flip";

        public override string ChangeSide_None_Description => "Do not change the placement side.";

        public override string ChangeSide_Top_Description => "Place the component on the top side.";

        public override string ChangeSide_Bottom_Description => "Place the component on the bottom side.";

        public override string ChangeSide_Reverse_Description => "Flip the placement side from the original side.";

        public override string RotationAdjustment_None_Display_Text => "None";

        public override string RotationAdjustment_Rot90_Display_Text => "90° CCW";

        public override string RotationAdjustment_Rot180_Display_Text => "180° CCW";

        public override string RotationAdjustment_Rot270_Display_Text => "270° CCW";

        public override string RuleAction_Convert_Display_Text => "Apply Rule";

        public override string RuleAction_Exclude_Display_Text => "Exclude";

        public override string RuleAction_Passthrough_Display_Text => "Pass Through";

        public override string RuleAction_Convert_Description => "Apply this conversion rule and output the result.";

        public override string RuleAction_Exclude_Description => "Do not output footprints that match the key.";

        public override string RuleAction_Passthrough_Description => "Output matching footprints without applying any conversion rule.";
    }
}
