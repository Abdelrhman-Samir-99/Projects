class CreateRecords < ActiveRecord::Migration[6.1]
  def change
    create_table :records do |t|
      t.references :User, null: false, foreign_key: true
      t.integer :Calories, default: 0, null: false
      t.string :place
      t.text :Notes
     
      t.timestamps
    end
  end
end
