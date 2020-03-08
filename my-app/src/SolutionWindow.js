import './Window.css';
import React from 'react';

export default class SolutionWindow extends React.Component {

    constructor(props) {
        super(props);
        this.state = {
            rowCount: 0,
            columnCount: 0,
            matrix: null,
            goods: null,
            needs: null
        };

        this.handleMatrixChange = this.handleMatrixChange.bind(this);
        this.handleInputChange = this.handleInputChange.bind(this);
        this.handleGoodsChange = this.handleGoodsChange.bind(this);
        this.handleNeedsChange = this.handleNeedsChange.bind(this);
    }

    handleInputChange(event) {

        let target = event.target;
        let value = target.value;
        let name = target.name;

        if (isNaN(parseInt(value))) {
            this.setState({
                [name]: 0,
            })
        } else {
            this.setState({
                [name]: parseInt(value),
            })
        }
    }

    handleMatrixChange(event) {

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

    handleGoodsChange(event) {

        let target = event.target;
        let value = target.value;
        let name = target.name;

        let goods = this.state.goods;

        if (isNaN(parseInt(value))) {
            goods[parseInt(name)] = 0;
        } else {
            goods[parseInt(name)] = parseInt(value);
        }

        this.setState(() => {
            return {};
        });
    }

    handleNeedsChange(event) {

        let target = event.target;
        let value = target.value;
        let name = target.name;

        let needs = this.state.needs;

        if (isNaN(parseInt(value))) {
            needs[parseInt(name)] = 0;
        } else {
            needs[parseInt(name)] = parseInt(value);
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

    initializeResult() {

    }

    solveMatrix() {

        let data = {
            matrix: this.state.matrix,
            goods: this.state.goods,
            needs: this.state.needs,
        };

        fetch('http://localhost:5000/api/ticket/ticket',
            {
                method: "put",
                body: JSON.stringify(data),
                headers:
                    {
                        'Accept': 'application/json',
                        'Content-Type': 'application/json',
                    }
            })
            .then(response => {
                if (response.status >= 200 && response.status < 300) {

                    return response.json().then((data) => this.initializeResult(data));
                }
            })
    }

    render() {

        let columnCount;
        let rowCount;
        let matrix;
        let goods;
        let needs;
        let solve;

        if (this.state.rowCount == 0 || this.state.columnCount == 0) {

            rowCount =
                <div className="rowCount">
                    Row count:
                    <input onChange={this.handleInputChange}
                           className="rowCountInput" name="rowCount"
                           value={this.state.rowCount}/>
                </div>;

            columnCount =
                <div className="columnCount">
                    Column count:
                    <input onChange={this.handleInputChange}
                           className="columnCountInput"
                           name="columnCount"
                           value={this.state.columnCount}/>
                </div>;
        }

        if (this.state.rowCount > 0 && this.state.columnCount > 0) {
            this.initializeMatrix();

            if (this.state.matrix != null) {
                matrix = this.state.matrix.map((row, rowId) => (
                    <div className="row" name="row" row={row}>
                        {row.map((elem, id) => (
                            <input
                                className="elem"
                                name={rowId + "" + id}
                                onChange={this.handleMatrixChange}
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
                goods = this.state.goods.map((good, id) =>
                    <input onChange={this.handleGoodsChange} name={id} className="elem" value={good}/>
                );
            }
        }

        if (this.state.matrix != null) {
            this.initializeNeeds();

            if (this.state.needs != null) {
                needs = this.state.needs.map((need, id) =>
                    <input onChange={this.handleNeedsChange} name={id} className="elem" value={need}/>
                );
            }
        }

        if (this.state.matrix != null) {
            solve = <button
                className="solveButton"
                onClick={this.solveMatrix}>
                Решить</button>
        }

        return (
            <div className="app">

                <div>
                    {rowCount}
                    {columnCount}
                </div>

                <div className="inline">
                    <div className="matrix">{matrix}</div>
                    <div className="goods">{goods}</div>
                </div>

                <div className="needs">{needs}</div>

                <div>
                    {solve}
                </div>

            </div>
        );
    }
}

