namespace PCBAssemblyConverter.Localization.Resources
{
    public class LocalizeJP : LocalizeBase
    {
        public override string Home_About_Header => "このプログラムについて";

        public override string Home_About_Sentence_1 => "基板設計ソフトから出力された BOM / P0S ファイルを、各基板製造業者の入稿ファイルに変換します。";
        
        public override string Home_About_Sentence_2 => "変換された BOM / POS ファイルと、変換ルールをまとめた JSON ファイルが ZIP でダウンロードできます。";

        public override string Home_Support_Header => "対応ソフト / 業者";

        public override string Home_Support_Eda => "対応ソフト";

        public override string Home_Support_Manufacturer => "対応業者";

        public override string Home_HowToUse_Header => "使い方";

        public override string Home_HowToUse_Step_1 => "ソフトと業者を選択する";

        public override string Home_HowToUse_Step_2 => "BOM / POS ファイルを読み込ませる";

        public override string Home_HowToUse_Step_3 => "変換ルールを設定する";

        public override string Home_HowToUse_Step_3_SubSentence_1 => "直接編集する";

        public override string Home_HowToUse_Step_3_SubSentence_2 => "すでにある JSON を読み込ませる";

        public override string Home_HowToUse_Step_4 => "変換してダウンロードする";

        public override string Home_StartButton_Text => "はじめる";

        public override string Converter_InOut_Selector_Header => "変換設定";

        public override string Converter_BomData_Header => "BOM プレビュー";

        public override string Converter_PosData_Header => "POS プレビュー";

        public override string Converter_BomPos_Input_Header => "入力ファイル";

        public override string Converter_BomPos_Input_Bom_DDButton_Text => "BOM";

        public override string Converter_BomPos_Input_Bom_DDButton_Description => "クリック か ドラッグ&ドロップ でファイル選択";

        public override string Converter_BomPos_Input_Bom_DDButton_SubDescription => "対応ファイル";

        public override string Converter_BomPos_Input_Pos_DDButton_Text => "POS";

        public override string Converter_BomPos_Input_Pos_DDButton_Description => "クリック か ドラッグ&ドロップ でファイル選択";

        public override string Converter_BomPos_Input_Pos_DDButton_SubDescription => "対応ファイル";

        public override string Converter_ConversionRule_Editor_Header => "変換ルール設定";

        public override string Converter_ConversionRule_Editor_ConversionRule_DDButton_Text => "変換ルール";

        public override string Converter_ConversionRule_Editor_ConversionRule_DDButton_Description => "クリック か ドラッグ&ドロップ でファイル選択";

        public override string Converter_ConversionRule_Editor_ConversionRule_DDButton_SubDescription => "対応ファイル";

        public override string Converter_Result_Header => "出力";

        public override string Converter_ConvertButton_Text => "変換";

        public override string Converter_DownloadButton_Text => "ダウンロード";

        public override string Converter_Error_Message_is_not_supported => "は非対応です。";

        public override string Converter_Error_Message_file_load_failed => "ファイル読み込み中にエラーが発生しました。";

        public override string Converter_Error_Message_should_select_json => "JSON ファイルを選択してください。";

        public override string Converter_Error_Message_ConversionRule_load_failed => "変換ルールの読み込みに失敗しました。";

        public override string Converter_Error_Message_Bom_convert_failed => "BOM ファイルの変換に失敗しました。";

        public override string Converter_Error_Message_Pos_convert_failed => "POS ファイルの変換に失敗しました。";

        public override string Converter_Error_Message_download_file_create_failed => "ダウンロードファイルの生成に失敗しました。";

        public override string Converter_Notice_Message_Bom_loaded => "BOM ファイルを読み込みました。";

        public override string Converter_Notice_Message_Pos_loaded => "POS ファイルを読み込みました。";

        public override string Converter_Notice_Message_ConversionRule_loaded => "変換ルールを読み込みました。";

        public override string Converter_Notice_Message_convert_finished => "変換が完了しました。";

        public override string FileName_Display_Text => "ファイル名";

        public override string RecordCount_Display_Text => "レコード数";

        public override string RecordCount_Format => "件";

        public override string Message_no_data_to_display => "データがありません。";

        public override string ConversionRuleGrid_EditButton_Text => "編集";

        public override string ConversionRuleGrid_SaveButton_Text => "保存";

        public override string ConversionRuleGrid_CancelButton_Text => "キャンセル";

        public override string ConversionRule_Description_Header => "変換ルールについて";

        public override string ConversionRule_SpecTable_Header_Name => "項目名";

        public override string ConversionRule_SpecTable_Header_DataType => "データ型";

        public override string ConversionRule_SpecTable_Header_Enum => "選択肢";

        public override string ConversionRule_SpecTable_Header_Description => "説明";

        public override string ConversionRule_SpecTable_Name_Property_DataType => "文字列";

        public override string ConversionRule_SpecTable_Name_Property_Enum => "-";

        public override string ConversionRule_SpecTable_Name_Property_Description_Sentence_1 => "ルールの名前。";

        public override string ConversionRule_SpecTable_Key_Property_DataType => "文字列";

        public override string ConversionRule_SpecTable_Key_Property_Enum => "-";

        public override string ConversionRule_SpecTable_Key_Property_Description_Sentence_1 => "変換ルールの適用対象となるフットプリントを検索するためのキー。";

        public override string ConversionRule_SpecTable_MatchingStrategy_Property_DataType => "選択";

        public override string ConversionRule_SpecTable_MatchingStrategy_Property_Enum => "";

        public override string ConversionRule_SpecTable_OffsetX_Property_DataType => "小数点";

        public override string ConversionRule_SpecTable_OffsetX_Property_Enum => "-";

        public override string ConversionRule_SpecTable_OffsetX_Property_Description_Sentence_1 => "フットプリント原点から実際の部品実装位置までの X オフセット。";

        public override string ConversionRule_SpecTable_OffsetY_Property_DataType => "小数点";

        public override string ConversionRule_SpecTable_OffsetY_Property_Enum => "-";

        public override string ConversionRule_SpecTable_OffsetY_Property_Description_Sentence_1 => "フットプリント原点から実際の部品実装位置までの Y オフセット。";

        public override string ConversionRule_SpecTable_ChangeSide_Property_DataType => "選択";

        public override string ConversionRule_SpecTable_ChangeSide_Property_Enum => "";

        public override string ConversionRule_SpecTable_RatationAdjustment_Property_DataType => "選択";

        public override string ConversionRule_SpecTable_RatationAdjustment_Property_Enum => "";

        public override string ConversionRule_SpecTable_RatationAdjustment_Property_Description_Sentence_1 => "フットプリントの回転角と実際の部品の回転角との差を補正する。";

        public override string ConversionRule_SpecTable_ManufacturerPartNumber_Property_DataType => "文字列";

        public override string ConversionRule_SpecTable_ManufacturerPartNumber_Property_Enum => "-";

        public override string ConversionRule_SpecTable_ManufacturerPartNumber_Property_Description_Sentence_1 => "実装するパーツの業者番号。";

        public override string ConversionRule_SpecTable_ManufacturerPartNotes_Property_DataType => "文字列";

        public override string ConversionRule_SpecTable_ManufacturerPartNotes_Property_Enum => "-";

        public override string ConversionRule_SpecTable_ManufacturerPartNotes_Property_Description_Sentence_1 => "実装するパーツの参考資料（データシートや調達先のリンクなど）が必要であればここに入力。";

        public override string ConversionRule_SpecTable_ManufacturerPartNotes_Property_Description_Sentence_2 => "メモとしても使用可能。";

        public override string ConversionRule_SpecTable_RuleAction_Property_DataType => "選択";

        public override string ConversionRule_SpecTable_RuleAction_Property_Enum => "";

        public override string ConversionRule_Name_Property_Display_Text => "ルール名";

        public override string ConversionRule_Key_Property_Display_Text => "キー";

        public override string ConversionRule_MatchingStrategy_Property_Display_Text => "検索条件";

        public override string ConversionRule_OffsetX_Property_Display_Text => "Offset X";

        public override string ConversionRule_OffsetY_Property_Display_Text => "Offset Y";

        public override string ConversionRule_ChangeSide_Property_Display_Text => "実装面変更";

        public override string ConversionRule_RotationAdjustment_Property_Display_Text => "回転";

        public override string ConversionRule_ManufacturerPartNumber_Property_Display_Text => "パーツ業者番号";

        public override string ConversionRule_ManufacturerPartNotes_Property_Display_Text => "パーツ参考資料";

        public override string ConversionRule_RuleAction_Property_Display_Text => "ルール適用";

        public override string MatchingStrategy_Exact_Display_Text => "完全一致";

        public override string MatchingStrategy_Contains_Display_Text => "部分一致";

        public override string MatchingStrategy_Regex_Display_Text => "正規表現";

        public override string MatchingStrategy_Exact_Description => "キー文字列と完全に一致するフットプリントに対してルールを適用する。";

        public override string MatchingStrategy_Contains_Description => "キー文字列を含むフットプリントに対してルールを適用する。";

        public override string MatchingStrategy_Regex_Description => "キー文字列に入力された正規表現と一致するフットプリントに対してルールを適用する。";

        public override string ChangeSide_None_Display_Text => "なし";

        public override string ChangeSide_Top_Display_Text => "トップ";

        public override string ChangeSide_Bottom_Display_Text => "ボトム";

        public override string ChangeSide_Reverse_Display_Text => "反転";

        public override string ChangeSide_None_Description => "変更しない。";

        public override string ChangeSide_Top_Description => "トップに変更。";

        public override string ChangeSide_Bottom_Description => "ボトムに変更。";

        public override string ChangeSide_Reverse_Description => "元の実装面から反転させる。";

        public override string RotationAdjustment_None_Display_Text => "なし";

        public override string RotationAdjustment_Rot90_Display_Text => "90° 反時計回り";

        public override string RotationAdjustment_Rot180_Display_Text => "180° 反時計回り";

        public override string RotationAdjustment_Rot270_Display_Text => "270° 反時計回り";

        public override string RuleAction_Convert_Display_Text => "変換して出力";

        public override string RuleAction_Exclude_Display_Text => "出力しない";

        public override string RuleAction_Passthrough_Display_Text => "そのまま出力";

        public override string RuleAction_Convert_Description => "キーと一致したフットプリントについて、変換ルールを適用して入稿ファイルに出力する。";

        public override string RuleAction_Exclude_Description => "キーと一致したフットプリントは、入稿ファイルに出力しない。";

        public override string RuleAction_Passthrough_Description => "キーと一致したフットプリントについて、変換せずにそのまま入稿ファイルに出力する。";
    }
}
