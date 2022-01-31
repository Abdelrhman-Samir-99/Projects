class CreateRecordItems < ActiveRecord::Migration[6.1]
  def change
    create_table :record_items do |t|
      t.references :Record, null: false, foreign_key: true
      t.references :Meal, null: false, foreign_key: true
      
      t.timestamps
    end
  end
end
