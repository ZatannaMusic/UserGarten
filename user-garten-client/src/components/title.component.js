import React, { Component } from 'react';
import TextField from '@material-ui/core/TextField';
import Button from '@material-ui/core/Button';
import Form from 'react-bootstrap/Form';
import Col from 'react-bootstrap/Col';
import ResultSizes from "./result-sizes";

export default class Title extends Component {

    constructor(props) {
        super(props);
        this.state = {
            queryText: "",
            condition: "Contains"
        }
    }

    componentDidMount = () => {
        let queryTextData = localStorage.getItem("serler_queryText");
        if (queryTextData != null) {
            let queryText = JSON.parse(queryTextData);
            this.setState({ queryText: queryText });
        }

        let conditionData = localStorage.getItem("serler_condition");
        if (conditionData != null) {
            let condition = JSON.parse(conditionData);
            this.setState({ condition: condition });
        }
    }

    onSearch = (event) => {
        this.props.callback();
    }

    onCreate = (event) => {
        this.props.callback();
    }

    updateQueryTextValue = (event) => {
        this.setState({ queryText: event.target.value });
        localStorage.setItem("serler_queryText", JSON.stringify(event.target.value));
    }

    onConditionChange = (event) => {
        this.setState({ condition: event.target.value });
        localStorage.setItem("serler_condition", JSON.stringify(event.target.value));
    }

    render() {
        return (
            <div>
                <Form.Row>
                    <Col>
                        <TextField
                            id="first-name-field"
                            label="First name"
                            value={this.state.queryText}
                            onChange={this.updateQueryTextValue}
                            onSubmit={this.onSearch}
                            margin="normal"
                            variant="outlined"
                            fullWidth
                        />
                    </Col>
                    <Col>
                        <TextField
                            id="last-name-field"
                            label="Last name"
                            value={this.state.queryText}
                            onChange={this.updateQueryTextValue}
                            onSubmit={this.onSearch}
                            margin="normal"
                            variant="outlined"
                            fullWidth
                        />
                    </Col>
                    <Col xs lg="2">
                        <TextField
                            id="result-sile-list"
                            select
                            label="Result max size"
                            SelectProps={{
                                native: true,
                                MenuProps: {
                                },
                            }}
                            helperText="Count of records"
                            margin="normal"
                            variant="outlined"
                            fullWidth
                            value={this.state.condition}
                            onChange={this.onConditionChange}
                        >
                            {ResultSizes.map(option => (
                                <option key={option.value} value={option.value}>
                                    {option.label}
                                </option>
                            ))}
                        </TextField>
                    </Col>
                </Form.Row>
                <Button variant="contained" color="primary"
                    onClick={this.onSearch}
                >
                    Search
                </Button>
                <Button variant="contained" color="primary"
                    onClick={this.onCreate}
                >
                    Create
                </Button>
            </div>
        );
    }
}
