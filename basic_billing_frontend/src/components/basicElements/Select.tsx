import React from "react";

interface CategorySelectOptionsProps {
  onSelectOptionChange: (SelectedKey: string) => void;
  DictionaryKeyValues: { [key: string]: string };
}

export const Select: React.FC<CategorySelectOptionsProps> = ({ onSelectOptionChange, DictionaryKeyValues }) => {
  const handleChange = (e: React.ChangeEvent<HTMLSelectElement>) => {
    onSelectOptionChange(e.target.value);
  };
  return (
    <select
      style={{
        textAlign: "center",
        background: "#80808080",
        borderStyle: "solid",
      }}
      name="category"
      onChange={(e) => handleChange(e)}
    >
      {Object.keys(DictionaryKeyValues).map((key) => (
        <option key={key} value={key}>
          {DictionaryKeyValues[key]}
        </option>
      ))}
    </select>
  );
};
