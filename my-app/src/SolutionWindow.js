import React from 'react';
import {render} from 'react-dom';

export default class SolutionWindow extends React.Component {

    constructor(props) {
        super(props);
        this.state = {
            rowCount: 2,
            columnCount: 4,
            matrix: null,
            goods: null,
            needs: null
        };
        this.handleInputChange = this.handleInputChange.bind(this);
    }

    handleInputChange(event) {
        let target = event.target;
        let value = target.value;
        let name = target.name;

        let row = parseInt(name[0]);
        let column = parseInt(name[1]);
        let matrix = this.state.matrix;

        if (isNaN(parseInt(value))) {
            matrix[row][column] = 0;
        } else {
            matrix[row][column] = parseInt(value);
        }

        this.setState(() => {
            return {};
        });
    }

    initializeMatrix() {
        if (this.state.matrix == null) {
            let matrix = [];
            for (let row = 0; row < this.state.rowCount; row++) {
                matrix[row] = [];
                for (let column = 0; column < this.state.columnCount; column++) {
                    matrix[row][column] = 0;
                }
            }
            this.setState(() => {
                return {
                    matrix: matrix
                };
            });
        }
    }

    initializeGoods() {
        if (this.state.goods == null) {

            let goods = this.state.goods;
            goods = [];

            for (let i = 0; i < this.state.rowCount; i++) {
                goods[i] = 0;
            }

            this.setState(() => {
                return {
                    goods: goods
                };
            });
        }
    }

    initializeNeeds() {
        if (this.state.needs == null) {
            let needs = this.state.needs;
            needs = [];

            for (let i = 0; i < this.state.columnCount; i++) {
                needs[i] = 0;
            }

            this.setState(() => {
                return {
                    needs: needs
                };
            });
        }
    }

    render() {

        let matrix;
        let goods;
        let needs;

        if (this.state.rowCount > 0 && this.state.columnCount > 0) {
            this.initializeMatrix();

            if (this.state.matrix != null) {
                matrix = this.state.matrix.map((row, rowId) => (
                    <div name="row" row={row}>
                        {row.map((elem, id) => (
                            <input
                                name={rowId + "" + id}
                                onChange={this.handleInputChange}
                                value={elem}
                            />
                        ))}
                    </div>
                ));
            }
        }

        if (this.state.matrix != null) {
            this.initializeGoods();

            if (this.state.goods != null) {
                goods = this.state.goods.map(good =>
                    <div>
                        <input value={good}/>
                    </div>);
            }
        }

        if (this.state.matrix != null) {
            this.initializeGoods();

            if (this.state.goods != null) {
                goods = this.state.goods.map(good => <input value={good}/>);
            }
        }

        return (
            <div>
                {matrix}
                <div>------</div>
                {goods}
            </div>
        );
    }
}

