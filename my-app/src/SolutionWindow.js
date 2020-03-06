import * as React from "react";

export default class SolutionWindow extends React.Component {

    constructor(props) {
        super(props);

        this.state = {

            rowCount: 0,
            columnCount: 0,
            matrix : null,
        }
    }

    initializeMatrix() {
               
        if (this.state.rowCount > 0 && this.state.columnCount > 0) {

            if (this.state.matrix != null) {
                return;
            }

            let matrix = new Array();

            for (let row = 0; row < this.state.rowCount; row++) {

                matrix[row] = new Array();

                for (let column = 0; column < this.state.columnCount; column++) {

                    matrix[row][column] = 0;
                }
            }

            this.setState(() => {
                return {
                    matrix: matrix,
                };
            })            
        }       
    }

    render() {

        initializeMatrix();

        const matrix = this.state.matrix.map((row) =>
            <div>{row[0]}</div>
            )
    }
}


/*
import React from 'react';
import { render } from 'react-dom';
class ParentComponent extends React.Component {

  constructor(props) {
    super(props);

    this.state = {

        rowCount: 0,
        columnCount: 0,
        matrix : null,
        goods : null,
        needs : null,
    }

    this.handleInputChange = this.handleInputChange.bind(this);
}

handleInputChange(event) {

  let target = event.target;
  let value = target.value;
  let name = target.name;

  let row = parseInt(name[0]);
  let column = parseInt(name[1]);
  let matrix = this.state.matrix

  if (isNaN(parseInt(value))){
    matrix[row][column] = 0;
  }
  else{
    matrix[row][column] = parseInt(value);
  }

  this.setState(() => {
    return {

    };
})
}

initializeMatrix() {

  if (this.state.matrix == null)
  {
    let matrix = [];

      for (let row = 0; row < this.state.rowCount; row++) {

          matrix[row] = [];


          for (let column = 0; column < this.state.columnCount; column++) {

              matrix[row][column] = 0;
          }
      }

      this.setState(() => {
        return {
          matrix : matrix,
        };
      })
  }
  }

  render() {

    let matrix;
    let viewMatrix;

    if (this.state.rowCount > 0 && this.state.columnCount > 0) {

      matrix = this.initializeMatrix();

      if (this.state.matrix != null){
        viewMatrix = this.state.matrix.map((row, rowId) =>
        <div name="row" row = {row}>

             {
               row.map((elem, id) =>
               <input name={rowId+ "" + id} onChange={this.handleInputChange} value = {elem}>

               </input>)
             }

        </div> );
      }
    }

    return (
      <div>
           {viewMatrix}
      </div>
    )
  }}

render(<ParentComponent />, document.getElementById('root'));
 */