namespace PCBAssemblyConverter.Localization
{
    public interface ILocalize
    {
        public string Home_About_Header { get; }
        public string Home_About_Sentence_1 { get; }
        public string Home_About_Sentence_2 { get; }
        public string Home_Support_Header { get; }
        public string Home_Support_Eda { get; }
        public string Home_Support_Manufacturer { get; }
        public string Home_HowToUse_Header { get; }
        public string Home_HowToUse_Step_1 { get; }
        public string Home_HowToUse_Step_2 { get; }
        public string Home_HowToUse_Step_3 { get; }
        public string Home_HowToUse_Step_3_SubSentence_1 { get; }
        public string Home_HowToUse_Step_3_SubSentence_2 { get; }
        public string Home_HowToUse_Step_4 { get; }
        public string Home_StartButton_Text { get; }

        public string Converter_InOut_Selector_Header { get; }

        public string Converter_BomData_Header { get; }
        public string Converter_PosData_Header { get; }

        public string Converter_BomPos_Input_Header { get; }
        public string Converter_BomPos_Input_Bom_DDButton_Text { get; }
        public string Converter_BomPos_Input_Bom_DDButton_Description { get; }
        public string Converter_BomPos_Input_Bom_DDButton_SubDescription { get; }
        public string Converter_BomPos_Input_Pos_DDButton_Text { get; }
        public string Converter_BomPos_Input_Pos_DDButton_Description { get; }
        public string Converter_BomPos_Input_Pos_DDButton_SubDescription { get; }

        public string Converter_ConversionRule_Editor_Header { get; }
        public string Converter_ConversionRule_Editor_ConversionRule_DDButton_Text { get; }
        public string Converter_ConversionRule_Editor_ConversionRule_DDButton_Description { get; }
        public string Converter_ConversionRule_Editor_ConversionRule_DDButton_SubDescription { get; }

        public string Converter_Result_Header { get; }
        public string Converter_ConvertButton_Text { get; }
        public string Converter_DownloadButton_Text { get; }

        public string Converter_Error_Message_is_not_supported { get; }
        public string Converter_Error_Message_file_load_failed { get; }
        public string Converter_Error_Message_should_select_json { get; }
        public string Converter_Error_Message_ConversionRule_load_failed { get; }
        public string Converter_Error_Message_Bom_convert_failed { get; }
        public string Converter_Error_Message_Pos_convert_failed { get; }
        public string Converter_Error_Message_download_file_create_failed { get; }
        public string Converter_Notice_Message_Bom_loaded { get; }
        public string Converter_Notice_Message_Pos_loaded { get; }
        public string Converter_Notice_Message_ConversionRule_loaded { get; }
        public string Converter_Notice_Message_convert_finished { get; }

        public string FileName_Display_Text { get; }
        public string RecordCount_Display_Text { get; }
        public string RecordCount_Format { get; }
        public string Message_no_data_to_display { get; }

        public string ConversionRuleGrid_EditButton_Text { get; }
        public string ConversionRuleGrid_SaveButton_Text { get; }
        public string ConversionRuleGrid_CancelButton_Text { get; }

        public string ConversionRule_Description_Header { get; }
        public string ConversionRule_SpecTable_Header_Name { get; }
        public string ConversionRule_SpecTable_Header_DataType { get; }
        public string ConversionRule_SpecTable_Header_Enum { get; }
        public string ConversionRule_SpecTable_Header_Description { get; }
        public string ConversionRule_SpecTable_Name_Property_DataType { get; }
        public string ConversionRule_SpecTable_Name_Property_Enum { get; }
        public string ConversionRule_SpecTable_Name_Property_Description_Sentence_1 { get; }
        public string ConversionRule_SpecTable_Key_Property_DataType { get; }
        public string ConversionRule_SpecTable_Key_Property_Enum { get; }
        public string ConversionRule_SpecTable_Key_Property_Description_Sentence_1 { get; }
        public string ConversionRule_SpecTable_MatchingStrategy_Property_DataType { get; }
        public string ConversionRule_SpecTable_MatchingStrategy_Property_Enum { get; }
        public string ConversionRule_SpecTable_OffsetX_Property_DataType { get; }
        public string ConversionRule_SpecTable_OffsetX_Property_Enum { get; }
        public string ConversionRule_SpecTable_OffsetX_Property_Description_Sentence_1 { get; }
        public string ConversionRule_SpecTable_OffsetY_Property_DataType { get; }
        public string ConversionRule_SpecTable_OffsetY_Property_Enum { get; }
        public string ConversionRule_SpecTable_OffsetY_Property_Description_Sentence_1 { get; }
        public string ConversionRule_SpecTable_ChangeSide_Property_DataType { get; }
        public string ConversionRule_SpecTable_ChangeSide_Property_Enum { get; }
        public string ConversionRule_SpecTable_RatationAdjustment_Property_DataType { get; }
        public string ConversionRule_SpecTable_RatationAdjustment_Property_Enum { get; }
        public string ConversionRule_SpecTable_RatationAdjustment_Property_Description_Sentence_1 { get; }
        public string ConversionRule_SpecTable_ManufacturerPartNumber_Property_DataType { get; }
        public string ConversionRule_SpecTable_ManufacturerPartNumber_Property_Enum { get; }
        public string ConversionRule_SpecTable_ManufacturerPartNumber_Property_Description_Sentence_1 { get; }
        public string ConversionRule_SpecTable_ManufacturerPartNotes_Property_DataType { get; }
        public string ConversionRule_SpecTable_ManufacturerPartNotes_Property_Enum { get; }
        public string ConversionRule_SpecTable_ManufacturerPartNotes_Property_Description_Sentence_1 { get; }
        public string ConversionRule_SpecTable_ManufacturerPartNotes_Property_Description_Sentence_2 { get; }
        public string ConversionRule_SpecTable_RuleAction_Property_DataType { get; }
        public string ConversionRule_SpecTable_RuleAction_Property_Enum { get; }

        public string ConversionRule_Name_Property_Display_Text { get; }
        public string ConversionRule_Key_Property_Display_Text { get; }
        public string ConversionRule_MatchingStrategy_Property_Display_Text { get; }
        public string ConversionRule_OffsetX_Property_Display_Text { get; }
        public string ConversionRule_OffsetY_Property_Display_Text { get; }
        public string ConversionRule_ChangeSide_Property_Display_Text { get; }
        public string ConversionRule_RotationAdjustment_Property_Display_Text { get; }
        public string ConversionRule_ManufacturerPartNumber_Property_Display_Text { get; }
        public string ConversionRule_ManufacturerPartNotes_Property_Display_Text { get; }
        public string ConversionRule_RuleAction_Property_Display_Text { get; }

        public string MatchingStrategy_Exact_Display_Text { get; }
        public string MatchingStrategy_Contains_Display_Text { get; }
        public string MatchingStrategy_Regex_Display_Text { get; }

        public string MatchingStrategy_Exact_Description { get; }
        public string MatchingStrategy_Contains_Description { get; }
        public string MatchingStrategy_Regex_Description { get; }

        public string ChangeSide_None_Display_Text { get; }
        public string ChangeSide_Top_Display_Text { get; }
        public string ChangeSide_Bottom_Display_Text { get; }
        public string ChangeSide_Reverse_Display_Text { get; }

        public string ChangeSide_None_Description { get; }
        public string ChangeSide_Top_Description { get; }
        public string ChangeSide_Bottom_Description { get; }
        public string ChangeSide_Reverse_Description { get; }

        public string RotationAdjustment_None_Display_Text { get; }
        public string RotationAdjustment_Rot90_Display_Text { get; }
        public string RotationAdjustment_Rot180_Display_Text { get; }
        public string RotationAdjustment_Rot270_Display_Text { get; }

        public string RuleAction_Convert_Display_Text { get; }
        public string RuleAction_Exclude_Display_Text { get; }
        public string RuleAction_Passthrough_Display_Text { get; }

        public string RuleAction_Convert_Description { get; }
        public string RuleAction_Exclude_Description { get; }
        public string RuleAction_Passthrough_Description { get; }

        public string Language_Japanese_Display_Text { get; }
        public string Language_English_Display_Text { get; }
    }
}
