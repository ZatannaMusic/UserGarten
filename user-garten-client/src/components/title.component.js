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
            firstName: "",
            lastName: "",
            maxResult: "all"
        }
    }

    componentDidMount = () => {
        let firstNameData = localStorage.getItem("usergarten_firstName");
        if (firstNameData != null) {
            let firstName = JSON.parse(firstNameData);
            this.setState({ firstName: firstName });
        }

        let lastNameData = localStorage.getItem("usergarten_lastName");
        if (lastNameData != null) {
            let lastName = JSON.parse(lastNameData);
            this.setState({ lastName: lastName });
        }

        let maxResultData = localStorage.getItem("usergarten_maxResult");
        if (maxResultData != null) {
            let maxResult = JSON.parse(maxResultData);
            this.setState({ maxResult: maxResult });
        }
    }

    onSearch = (event) => {
        this.props.callback();
    }

    onCreate = (event) => {
        this.props.callback();
    }

    updateFirstNameValue = (event) => {
        this.setState({ firstName: event.target.value });
        localStorage.setItem("usergarten_firstName", JSON.stringify(event.target.value));
    }

    updateLastNameValue = (event) => {
        this.setState({ lastName: event.target.value });
        localStorage.setItem("usergarten_lastName", JSON.stringify(event.target.value));
    }

    onMaxResultChange = (event) => {
        this.setState({ maxResult: event.target.value });
        localStorage.setItem("usergarten_maxResult", JSON.stringify(event.target.value));
    }

    render() {
        return (
            <div>
                <Form.Row>
                    <Col>
                        <TextField
                            id="first-name-field"
                            label="First name"
                            value={this.state.firstName}
                            onChange={this.updateFirstNameValue}
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
                            value={this.state.lastName}
                            onChange={this.updateLastNameValue}
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
                            value={this.state.maxResult}
                            onChange={this.onMaxResultChange}
                        >
                            {ResultSizes.map(option => (
                                <option key={option.value} value={option.value}>
                                    {option.label}
                                </option>
                            ))}
                        </TextField>
                    </Col>
                </Form.Row>
                <Form.Row>
                    <Col xs lg="1">
                        <Button variant="contained" color="primary"
                            onClick={this.onSearch}
                        >
                            Search
                        </Button>
                    </Col>
                    <Col>
                        <Button variant="contained" color="primary"
                            onClick={this.onCreate}
                        >
                            Create
                        </Button>
                    </Col>
                </Form.Row>
            </div>
        );
    }
}
