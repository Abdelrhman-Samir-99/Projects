class CreateRecordItems < ActiveRecord::Migration[6.1]
  def change
    create_table :record_items do |t|

      t.timestamps
    end
  end
end
