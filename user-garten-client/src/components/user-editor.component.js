import React, { Component } from 'react';
import Form from 'react-bootstrap/Form';
import TextField from '@material-ui/core/TextField';
import Col from 'react-bootstrap/Col';
import Titles from "./titles";
import Button from '@material-ui/core/Button';

import Logo from '../ok-logo.png';

export default class UserList extends Component {

    constructor(props) {
        super(props);
        this.state = {
            Id: null,
            Title: "",
            firstName: "",
            lastName: "",
            BirthDate: "",
            Phone: "",
            Base64Image: ""
        }
    }

    onSave = (event) => {
        //  this.props.create_callback();
    }

    render() {
        return (
            <div>
                <div className="py-3">
                    <h1>User Creation</h1>

                    <Form.Row>
                        <Col>
                            <Form.Row>
                                <TextField
                                    id="tile-list"
                                    select
                                    label="Title"
                                    SelectProps={{
                                        native: true,
                                        MenuProps: {
                                        },
                                    }}
                                    // helperText="Count of records"
                                    margin="normal"
                                    variant="outlined"
                                    fullWidth
                                    value={this.state.maxResult}
                                    onChange={this.onMaxResultChange}
                                >
                                    {Titles.map(option => (
                                        <option key={option.value} value={option.value}>
                                            {option.label}
                                        </option>
                                    ))}
                                </TextField>
                            </Form.Row>
                            <Form.Row>
                                <TextField
                                    id="first-name-field"
                                    label="First name"
                                    value={this.state.firstName}
                                    onChange={this.updateFirstNameValue}
                                    onSubmit={this.onSave}
                                    margin="normal"
                                    variant="outlined"
                                    fullWidth
                                />
                            </Form.Row>
                            <Form.Row>
                                <TextField
                                    id="last-name-field"
                                    label="Last name"
                                    value={this.state.lastName}
                                    onChange={this.updateFirstNameValue}
                                    onSubmit={this.onSave}
                                    margin="normal"
                                    variant="outlined"
                                    fullWidth
                                />
                            </Form.Row>
                            <Form.Row>
                                <TextField
                                    id="date"
                                    label="Birthday"
                                    type="date"
                                    defaultValue="1970-01-01"
                                    InputLabelProps={{
                                        shrink: true,
                                    }}
                                    margin="normal"
                                    fullWidth
                                />
                            </Form.Row>
                            <Form.Row>
                                <TextField
                                    id="phone-field"
                                    label="Phone"
                                    value={this.state.lastName}
                                    onChange={this.updateFirstNameValue}
                                    onSubmit={this.onSave}
                                    margin="normal"
                                    variant="outlined"
                                    fullWidth
                                />
                            </Form.Row>
                        </Col>
                        <Col xs lg="4">
                            <img className="" src={Logo} />
                        </Col>
                    </Form.Row>
                    <Form.Row>
                        <hr />
                    </Form.Row>
                    <Form.Row>
                        <Col xs lg="1">
                            <Button variant="contained" color="primary"
                                onClick={this.onSearch}
                            >
                                Save
                        </Button>
                        </Col>
                        <Col>
                            <Button variant="contained" color="secondary"
                                onClick={this.onCreate}
                            >
                                Cancel
                        </Button>
                        </Col>
                    </Form.Row>
                </div>
            </div>
        );
    }
}
